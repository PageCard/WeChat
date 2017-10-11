using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senparc.Weixin.MP.Entities.Menu;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP;
using Senparc.Weixin.Exceptions;
using System.Web;
using System.Web.Script.Serialization;
using System.Net;
using Senparc.Weixin.HttpUtility;
using Newtonsoft.Json;

namespace XCWeiXin.WeiXinComm
{
    public class MenuMgr
    {
        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="buttonData">菜单内容</param>
        /// <returns></returns>
        public Senparc.Weixin.MP.AppStore.WxJsonResult CreateMenu(string accessToken, ButtonGroup buttonData)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var jsonString = JsonConvert.SerializeObject(buttonData);
            CookieContainer cookieContainer = null;// new CookieContainer();
        
            using (MemoryStream ms = new MemoryStream())
            {
                var bytes = Encoding.UTF8.GetBytes(jsonString);
                ms.Write(bytes, 0, bytes.Length);
                ms.Seek(0, SeekOrigin.Begin);

                var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", accessToken);
                var result = Post.PostGetJson<Senparc.Weixin.MP.AppStore.WxJsonResult>(url, cookieContainer, ms);

              
                return result;
            }
        }

        /// <summary>
        /// 获取当前菜单，如果菜单不存在，将返回null
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public  GetMenuResult GetMenu(string accessTokenOrAppId)
        {
            return ApiHandlerWapper.TryCommonApi(accessToken =>
            {
                var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", accessToken.AsUrlData());

                var jsonString = RequestUtility.HttpGet(url, Encoding.UTF8);
                //var finalResult = GetMenuFromJson(jsonString);

                GetMenuResult finalResult;
                JavaScriptSerializer js = new JavaScriptSerializer();
                try
                {
                    var jsonResult = js.Deserialize<GetMenuResultFull>(jsonString);
                    if (jsonResult.menu == null || jsonResult.menu.button.Count == 0)
                    {
                        throw new WeixinException(jsonResult.errmsg);
                    }

                    finalResult = GetMenuFromJsonResult(jsonResult, new ButtonGroup());
                }
                catch (WeixinException ex)
                {
                    finalResult = null;
                }

                return finalResult;

            }, accessTokenOrAppId);
        }
        /// <summary>
        /// 根据微信返回的Json数据得到可用的GetMenuResult结果
        /// </summary>
        /// <param name="resultFull"></param>
        /// <param name="buttonGroupBase">ButtonGroupBase的衍生类型，可以为ButtonGroup或ConditionalButtonGroup。返回的GetMenuResult中的menu属性即为此示例。</param>
        /// <returns></returns>
        public static GetMenuResult GetMenuFromJsonResult(GetMenuResultFull resultFull, ButtonGroupBase buttonGroupBase)
        {
            GetMenuResult result = null;
            if (buttonGroupBase == null)
            {
                throw new ArgumentNullException("buttonGroupBase不可以为空！");
            }

            try
            {
                //重新整理按钮信息
                ButtonGroupBase buttonGroup = buttonGroupBase; // ?? new ButtonGroup();
                var rootButtonList = resultFull.menu.button;

                GetButtonGroup(rootButtonList, buttonGroup);//设置默认菜单
                result = new GetMenuResult(buttonGroupBase)
                {
                    menu = buttonGroup,
                    //conditionalmenu = resultFull.conditionalmenu
                };

                //设置个性化菜单列表
                if (resultFull.conditionalmenu != null)
                {
                    var conditionalMenuList = new List<ConditionalButtonGroup>();
                    foreach (var conditionalMenu in resultFull.conditionalmenu)
                    {
                        var conditionalButtonGroup = new ConditionalButtonGroup()
                            ;
                        //fix bug 16030701  https://github.com/JeffreySu/WeiXinMPSDK/issues/169
                        conditionalButtonGroup.matchrule = conditionalMenu.matchrule;
                        conditionalButtonGroup.menuid = conditionalMenu.menuid;
                        //fix bug 16030701 end

                        GetButtonGroup(conditionalMenu.button, conditionalButtonGroup);//设置默认菜单
                        conditionalMenuList.Add(conditionalButtonGroup);
                    }
                    result.conditionalmenu = conditionalMenuList;
                }
            }
            catch (Exception ex)
            {
                throw new WeixinMenuException(ex.Message, ex);
            }
            return result;
        }
        /// <summary>
        /// 从rootButtonList获取buttonGroup
        /// </summary>
        /// <param name="rootButtonList"></param>
        /// <param name="buttonGroup"></param>
        private static void GetButtonGroup(List<MenuFull_RootButton> rootButtonList, ButtonGroupBase buttonGroup)
        {
            foreach (var rootButton in rootButtonList)
            {
                if (string.IsNullOrEmpty(rootButton.name))
                {
                    continue; //没有设置一级菜单
                }
                var availableSubButton = rootButton.sub_button == null
                    ? 0
                    : rootButton.sub_button.Count(z => !string.IsNullOrEmpty(z.name)); //可用二级菜单按钮数量
                if (availableSubButton == 0)
                {
                    //底部单击按钮
                    if (rootButton.type == null ||
                        (rootButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase)
                         && string.IsNullOrEmpty(rootButton.key)))
                    {
                        throw new WeixinMenuException("单击按钮的key不能为空！");
                    }

                    if (rootButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase))
                    {
                        //点击
                        buttonGroup.button.Add(new SingleClickButton()
                        {
                            name = rootButton.name,
                            key = rootButton.key,
                            type = rootButton.type
                        });
                    }
                    else if (rootButton.type.Equals("VIEW", StringComparison.OrdinalIgnoreCase))
                    {
                        //URL
                        buttonGroup.button.Add(new SingleViewButton()
                        {
                            name = rootButton.name,
                            url = rootButton.url,
                            type = rootButton.type
                        });
                    }
                    else if (rootButton.type.Equals("LOCATION_SELECT", StringComparison.OrdinalIgnoreCase))
                    {
                        //弹出地理位置选择器
                        buttonGroup.button.Add(new SingleLocationSelectButton()
                        {
                            name = rootButton.name,
                            key = rootButton.key,
                            type = rootButton.type
                        });
                    }
                    else if (rootButton.type.Equals("PIC_PHOTO_OR_ALBUM", StringComparison.OrdinalIgnoreCase))
                    {
                        //弹出拍照或者相册发图
                        buttonGroup.button.Add(new SinglePicPhotoOrAlbumButton()
                        {
                            name = rootButton.name,
                            key = rootButton.key,
                            type = rootButton.type
                        });
                    }
                    else if (rootButton.type.Equals("PIC_SYSPHOTO", StringComparison.OrdinalIgnoreCase))
                    {
                        //弹出系统拍照发图
                        buttonGroup.button.Add(new SinglePicSysphotoButton()
                        {
                            name = rootButton.name,
                            key = rootButton.key,
                            type = rootButton.type
                        });
                    }
                    else if (rootButton.type.Equals("PIC_WEIXIN", StringComparison.OrdinalIgnoreCase))
                    {
                        //弹出微信相册发图器
                        buttonGroup.button.Add(new SinglePicWeixinButton()
                        {
                            name = rootButton.name,
                            key = rootButton.key,
                            type = rootButton.type
                        });
                    }
                    else if (rootButton.type.Equals("SCANCODE_PUSH", StringComparison.OrdinalIgnoreCase))
                    {
                        //扫码推事件
                        buttonGroup.button.Add(new SingleScancodePushButton()
                        {
                            name = rootButton.name,
                            key = rootButton.key,
                            type = rootButton.type
                        });
                    }
                    else
                    {
                        //扫码推事件且弹出“消息接收中”提示框
                        buttonGroup.button.Add(new SingleScancodeWaitmsgButton()
                        {
                            name = rootButton.name,
                            key = rootButton.key,
                            type = rootButton.type
                        });
                    }
                }
                //else if (availableSubButton < 2)
                //{
                //    throw new WeixinMenuException("子菜单至少需要填写2个！");
                //}
                else
                {
                    //底部二级菜单
                    var subButton = new SubButton(rootButton.name);
                    buttonGroup.button.Add(subButton);

                    foreach (var subSubButton in rootButton.sub_button)
                    {
                        if (string.IsNullOrEmpty(subSubButton.name))
                        {
                            continue; //没有设置菜单
                        }

                        if (subSubButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase)
                            && string.IsNullOrEmpty(subSubButton.key))
                        {
                            throw new WeixinMenuException("单击按钮的key不能为空！");
                        }


                        if (subSubButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase))
                        {
                            //点击
                            subButton.sub_button.Add(new SingleClickButton()
                            {
                                name = subSubButton.name,
                                key = subSubButton.key,
                                type = subSubButton.type
                            });
                        }
                        else if (subSubButton.type.Equals("VIEW", StringComparison.OrdinalIgnoreCase))
                        {
                            //URL
                            subButton.sub_button.Add(new SingleViewButton()
                            {
                                name = subSubButton.name,
                                url = subSubButton.url,
                                type = subSubButton.type
                            });
                        }
                        else if (subSubButton.type.Equals("LOCATION_SELECT", StringComparison.OrdinalIgnoreCase))
                        {
                            //弹出地理位置选择器
                            subButton.sub_button.Add(new SingleLocationSelectButton()
                            {
                                name = subSubButton.name,
                                key = subSubButton.key,
                                type = subSubButton.type
                            });
                        }
                        else if (subSubButton.type.Equals("PIC_PHOTO_OR_ALBUM", StringComparison.OrdinalIgnoreCase))
                        {
                            //弹出拍照或者相册发图
                            subButton.sub_button.Add(new SinglePicPhotoOrAlbumButton()
                            {
                                name = subSubButton.name,
                                key = subSubButton.key,
                                type = subSubButton.type
                            });
                        }
                        else if (subSubButton.type.Equals("PIC_SYSPHOTO", StringComparison.OrdinalIgnoreCase))
                        {
                            //弹出系统拍照发图
                            subButton.sub_button.Add(new SinglePicSysphotoButton()
                            {
                                name = subSubButton.name,
                                key = subSubButton.key,
                                type = subSubButton.type
                            });
                        }
                        else if (subSubButton.type.Equals("PIC_WEIXIN", StringComparison.OrdinalIgnoreCase))
                        {
                            //弹出微信相册发图器
                            subButton.sub_button.Add(new SinglePicWeixinButton()
                            {
                                name = subSubButton.name,
                                key = subSubButton.key,
                                type = subSubButton.type
                            });
                        }
                        else if (subSubButton.type.Equals("SCANCODE_PUSH", StringComparison.OrdinalIgnoreCase))
                        {
                            //扫码推事件
                            subButton.sub_button.Add(new SingleScancodePushButton()
                            {
                                name = subSubButton.name,
                                key = subSubButton.key,
                                type = subSubButton.type
                            });
                        }
                        else
                        {
                            //扫码推事件且弹出“消息接收中”提示框
                            subButton.sub_button.Add(new SingleScancodeWaitmsgButton()
                            {
                                name = subSubButton.name,
                                key = subSubButton.key,
                                type = subSubButton.type
                            });
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 备份菜单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public string GetMenuAdd(string appid,string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", accessToken);

            var jsonString = Senparc.Weixin.HttpUtility.RequestUtility.HttpGet(url, Encoding.UTF8);
            //var finalResult = GetMenuFromJson(jsonString);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/menuback/" + appid + ".txt"), false, System.Text.Encoding.GetEncoding("UTF-8"));
            sw.Write(jsonString);
            sw.Flush();
            sw.Close();
            sw.Dispose();
           

            return "备份完成";
        }

        /// <summary>
        /// 获取备份菜单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public GetMenuResult GetMenuBack(string appid)
        {
            StreamReader fr = new StreamReader(HttpContext.Current.Server.MapPath("~/menuback/"+appid+".txt"), System.Text.Encoding.GetEncoding("gb2312"));
            var jsonString = fr.ReadToEnd();
            fr.Close();
            fr.Dispose();    
         
            GetMenuResult finalResult;
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                var jsonResult = js.Deserialize<GetMenuResultFull>(jsonString);
                if (jsonResult.menu == null || jsonResult.menu.button.Count == 0)
                {
                    throw new WeixinException(jsonResult.errmsg);
                }

                finalResult = GetMenuFromJsonResult(jsonResult);
            }
            catch (WeixinException ex)
            {
                finalResult = null;
            }

            return finalResult;
        }


        /// <summary>
        /// 根据微信返回的Json数据得到可用的GetMenuResult结果
        /// </summary>
        /// <param name="resultFull"></param>
        /// <returns></returns>
        public GetMenuResult GetMenuFromJsonResult(GetMenuResultFull resultFull)
        {
            GetMenuResult result = null;
            try
            {
                //重新整理按钮信息
                ButtonGroup bg = new ButtonGroup();
                foreach (var rootButton in resultFull.menu.button)
                {
                    if (rootButton.name == null)
                    {
                        continue;//没有设置一级菜单
                    }
                    var availableSubButton = rootButton.sub_button.Count(z => !string.IsNullOrEmpty(z.name));//可用二级菜单按钮数量
                    if (availableSubButton == 0)
                    {
                        //底部单击按钮
                        if (rootButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase)
                            && string.IsNullOrEmpty(rootButton.key))
                        {
                            throw new WeixinMenuException("单击按钮的key不能为空！");
                        }

                        if (rootButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase))
                        {
                            //点击
                            bg.button.Add(new SingleClickButton()
                            {
                                name = rootButton.name,
                                key = rootButton.key,
                                type = rootButton.type
                            });
                        }
                        else
                        {
                            //URL
                            bg.button.Add(new SingleViewButton()
                            {
                                name = rootButton.name,
                                url = rootButton.url,
                                type = rootButton.type
                            });
                        }

                    }
                    //else if (availableSubButton < 1)
                    //{
                    //    throw new WeixinMenuException("子菜单至少需要填写1个！");
                    //}
                    else
                    {
                        //底部二级菜单
                        var subButton = new SubButton(rootButton.name);
                        bg.button.Add(subButton);

                        foreach (var subSubButton in rootButton.sub_button)
                        {
                            if (subSubButton.name == null)
                            {
                                continue; //没有设置菜单
                            }

                            if (subSubButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase)
                                && string.IsNullOrEmpty(subSubButton.key))
                            {
                                throw new WeixinMenuException("单击按钮的key不能为空！");
                            }


                            if (subSubButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase))
                            {
                                //点击
                                subButton.sub_button.Add(new SingleClickButton()
                                {
                                    name = subSubButton.name,
                                    key = subSubButton.key,
                                    type = subSubButton.type
                                });
                            }
                            else
                            {
                                //URL
                                subButton.sub_button.Add(new SingleViewButton()
                                {
                                    name = subSubButton.name,
                                    url = subSubButton.url,
                                    type = subSubButton.type
                                });
                            }
                        }
                    }
                }

                if (bg.button.Count < 1)
                {
                    throw new WeixinMenuException("一级菜单按钮至少为1个！");
                }

                result = new GetMenuResult(bg)
                {
                    menu = bg
                };
            }
            catch (Exception ex)
            {
                throw new WeixinMenuException(ex.Message, ex);
            }
            return result;
        }



        /// <summary>
        /// 获取当前菜单 json
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public string GetMenu2(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", accessToken);
            var jsonString = Senparc.Weixin.HttpUtility.RequestUtility.HttpGet(url, Encoding.UTF8);
            return jsonString;
        }


        // 从一个对象信息生成Json串
        public string ObjectToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            byte[] dataBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(dataBytes, 0, (int)stream.Length);
            return Encoding.UTF8.GetString(dataBytes);
        }

    }
}
