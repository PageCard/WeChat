﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using XCWeiXin.Common;
using VTemplate.Engine;
using System.Data.SqlClient;
using XCWeiXin.DBUtility;
namespace XCWeiXin.Templates
{
    public class ShopTemplateMgr
    {
        XCWeiXin.DAL.templatesDal tDal = new DAL.templatesDal();

        #region 属性
        protected internal string ccRight = "(c)2014 XX公司 技术提供";
        /// <summary>
        /// 当前页面的模板文档对象
        /// </summary>
        protected TemplateDocument Document
        {
            get;
            private set;
        }

        /// <summary>
        /// 当前页面的模板文档的配置参数
        /// </summary>
        protected virtual TemplateDocumentConfig DocumentConfig
        {
            get
            {
                return TemplateDocumentConfig.Default;
            }
        }

        /// <summary>
        /// 微帐号
        /// </summary>
        public int wid { get; set; }
        /// <summary>
        /// 微信用户openid
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 搜索关键词
        /// </summary>
        public string soStr { get; set; }

        /// <summary>
        /// 模版类型
        /// </summary>
        public TemplateType tType { get; set; }

        /// <summary>
        /// 模版文件名称
        /// </summary>
        public string templateFileName { get; set; }

        /// <summary>
        /// 模版文件的文件夹名称
        /// </summary>
        public string templateDictoryName { get; set; }

        /// <summary>
        /// 模版的物理路径（全完）
        /// </summary>
        public string serverPath { get; set; }
       
        /// <summary>
        /// 模版的虚拟路径，比如/shop/templates/default
        /// </summary>
        public string tPath { get; set; }
        #endregion

        #region 构造函数

        /// <summary>
        /// 模版初始化
        /// </summary>
        /// <param name="tPath">模版文件的虚拟路径</param>
        /// <param name="serverPath">模版文件的完全路径</param>
        /// <param name="wid"></param>
        public ShopTemplateMgr( string tPath, string serverPath, int wid)
        {

            this.serverPath = serverPath;
            this.tPath = tPath;
            this.Document = new TemplateDocument(serverPath, Encoding.UTF8, this.DocumentConfig);
            this.wid = wid;
        }

        /// <summary>
        /// 模版初始化
        /// </summary>
        /// <param name="templateDictoryName">模版文件的文件夹名称</param>
        /// <param name="tPath">模版文件的虚拟路径</param>
        /// <param name="serverPath">模版文件的完全路径</param>
        /// <param name="wid"></param>
        public ShopTemplateMgr(string templateDictoryName, string tPath, string serverPath, int wid)
        {
          
            this.templateDictoryName = templateDictoryName;
            this.serverPath = serverPath;
            this.tPath = tPath;
            this.Document = new TemplateDocument(serverPath, Encoding.UTF8, this.DocumentConfig);
            this.wid = wid;
        }


        /// <summary>
        /// 模版初始化
        /// </summary>
        /// <param name="templateFileName">模版文件的名称</param>
        /// <param name="templateDictoryName">模版文件的文件夹名称</param>
        /// <param name="tPath">模版文件的虚拟路径</param>
        /// <param name="serverPath">模版文件的完全路径</param>
        /// <param name="wid"></param>
        public ShopTemplateMgr(string templateFileName, string templateDictoryName, string tPath, string serverPath, int wid)
        {
            this.templateFileName = templateFileName;
            this.templateDictoryName = templateDictoryName;
            this.serverPath = serverPath;
            this.tPath = tPath;
            this.Document = new TemplateDocument(serverPath, Encoding.UTF8, this.DocumentConfig);
            this.wid = wid;
        }

        #endregion

        /// <summary>
        /// 输出最终的html
        /// </summary>
        /// <param name="templateFileName"></param>
        /// <param name="tPath"></param>
        /// <param name="wid"></param>
        public void OutPutHtml(int wid)
        {
            //注册一个自定义函数
            this.Document.RegisterGlobalFunction(this.ComputeMoney);

            //对VT模板里的config变量赋值 
            Model.wxcodeconfig wxconfig = tDal.GetModelByWid(wid, tPath);
            if (wxconfig.wxstatus == 0)
            {
              //  HttpContext.Current.Response.Write("帐号已过期！请及时充值！");
            }
            this.Document.Variables.SetValue("config", wxconfig);

            BLL.wx_shop_setting setBll = new BLL.wx_shop_setting();
            if (!setBll.ExistsWid(wid))
            {
                HttpContext.Current.Response.Write("请先选择模版！");
                HttpContext.Current.Response.End();
            }
            Model.wx_shop_setting setting = setBll.GetModelList("wid="+wid)[0];

            this.Document.Variables.SetValue("shopconfig", setting);

            this.Document.SetValue("wid", wid);
            this.Document.SetValue("ccright", ccRight);
            this.Document.SetValue("yuming", MyCommFun.getWebSite());
            this.Document.SetValue("thisurl", MyCommFun.getTotalUrl());
            this.Document.SetValue("indexurl", indexUrl());
            this.Document.SetValue("categoryurl", MyCommFun.urlAddOpenid("/shop/category.aspx?wid=" + wid, openid));
            this.Document.SetValue("carturl", MyCommFun.urlAddOpenid("/shop/cart.aspx?wid=" + wid, openid));
            this.Document.SetValue("userurl", MyCommFun.urlAddOpenid("/shop/userinfo.aspx?wid=" + wid, openid));
            this.Document.SetValue("openid", openid);
            this.Document.SetValue("soStr", soStr);
            this.Document.SetValue("cartcount", getCartCount());
            this.Document.Variables.SetValue("this", this);
            if (tType == TemplateType.Class)
            {
                ProductClassPage();
            }
            else if (tType == TemplateType.Index)
            {
                getalbums();
            }

            else if (tType == TemplateType.News)
            {
                ShopDetailPage();
                getalbums();
            }
            else if (tType == TemplateType.Cart)
            {
                CartDetailPage();
            }
            else   if (tType == TemplateType.confirmOrder)
            {
                confirmOrder();
            }
            else  if (tType == TemplateType.editaddr)
            {
                editAddrPage();
            }
            else if (tType == TemplateType.orderSuccess)
            {
                OrderSuccessPage();
            }
            else if (tType == TemplateType.userinfo)
            {
                userinfoPage();
            }
            else if (tType == TemplateType.orderDetail)
            {  //订单详情页面
                orderDetail();
            }
          
            //输出最终呈现的数据 
            this.Document.Render(HttpContext.Current.Response.Output);

        }

        #region 方法集合：注册到模版或者供模版调用

        public void ProductClassPage()
        {
            int category_id = MyCommFun.RequestInt("cid");
            //--=====begin: 将这个列表（文章类别）的基本信息展示出来 ====--
            DAL.wx_shop_category cateBll = new DAL.wx_shop_category();
            Model.wx_shop_category category = cateBll.GetCategoryByWid(wid, category_id);
            this.Document.SetValue("category", category);
            this.Document.SetValue("wid", wid);
            //--=====end: 将这个列表（文章类别）的基本信息展示出来 ====--

            Tag orderByTag = this.Document.GetChildTagById("norderby");
            string orderby = orderByTag.Attributes["value"].Value.ToString();

            Tag pagesizeTag = this.Document.GetChildTagById("npagesize");
            string pagesizeStr = pagesizeTag.Attributes["value"].Value.ToString();

            int currPage = 1;//当前页面
            int recordCount = 0;//总记录数
            int totPage = 1;//总页数
            int pageSize = MyCommFun.Str2Int(pagesizeStr);//每页的记录数
            if (pageSize <= 0)
            {
                pageSize = 10;
            }
            if (MyCommFun.RequestInt("page") > 0)
            {
                currPage = MyCommFun.RequestInt("page");
            }

            DataSet productlist = new DataSet();
            if (category_id != 0)
            {

                DAL.wx_shop_product artDal = new DAL.wx_shop_product();
                productlist = artDal.GetList(wid, category_id, pageSize, currPage, "upselling=1", orderby, out recordCount);
                if (productlist != null && productlist.Tables.Count > 0 && productlist.Tables[0].Rows.Count > 0)
                {
                    DataRow dr;
                    for (int i = 0; i < productlist.Tables[0].Rows.Count; i++)
                    {
                        dr = productlist.Tables[0].Rows[i];
                        if (dr["link_url"] != null && dr["link_url"].ToString().Trim().Length > 0)
                        {
                            dr["link_url"] = MyCommFun.urlAddOpenid(dr["link_url"].ToString().Trim(), openid);
                        }
                        else
                        {
                            dr["link_url"] = MyCommFun.urlAddOpenid("detail.aspx?wid=" + wid + "&pid=" + dr["id"].ToString(), openid);
                        }
                        productlist.AcceptChanges();
                    }

                    totPage = recordCount / pageSize;
                    int yushu = recordCount % pageSize;
                    if (yushu > 0)
                    {
                        totPage += 1;
                    }
                    if (totPage < 1)
                    {
                        totPage = 1;
                    }
                }
                if (currPage > totPage)
                {
                    currPage = totPage;
                }
            }
            else
            {
                currPage = 1;
                recordCount = 0;
                totPage = 1;
            }
            this.Document.SetValue("totPage", totPage);//总页数
            this.Document.SetValue("currPage", currPage);//当前页
            this.Document.SetValue("productlist", productlist);//文章列表

            string beforePageStr = ""; //上一页
            string nextPageStr = ""; //下一页
            string bgrey = "c-p-grey";
            string ngrey = "c-p-grey";
            if (currPage <= 1)
            {
                beforePageStr = "";
                bgrey = "c-p-grey";
            }
            else
            {
                beforePageStr = MyCommFun.ChangePageNum(MyCommFun.getTotalUrl(), (currPage - 1));
             //   beforePageStr = "href=\"" + beforePageStr + "\"";
                bgrey = "";
            }

            if (currPage >= totPage)
            {
                nextPageStr = "";
                ngrey = " c-p-grey";
            }
            else
            {
                nextPageStr = MyCommFun.ChangePageNum(MyCommFun.getTotalUrl(), (currPage + 1));
              //  nextPageStr = "href=\"" + nextPageStr + "\"";
                ngrey = "";
            }
            this.Document.SetValue("bpage", beforePageStr);//上一页
            this.Document.SetValue("npage", nextPageStr);//下一页
            this.Document.SetValue("bgrey", bgrey);//上一页灰色的样式
            this.Document.SetValue("ngrey", ngrey);//下一页灰色的样式



        }
        /// <summary>
        /// 商品列表
        /// </summary>
        public void ProductCategoryList() {

            int category_id = MyCommFun.RequestInt("cid");
            //--=====begin: 将这个列表（文章类别）的基本信息展示出来 ====--
            DAL.wx_shop_category cateBll = new DAL.wx_shop_category();
            Model.wx_shop_category category = cateBll.GetCategoryByWid(wid, category_id);
            this.Document.SetValue("category", category);
            this.Document.SetValue("wid", wid);
            //--=====end: 将这个列表（文章类别）的基本信息展示出来 ====--
        
        }
        
        /// <summary>
        /// 取商品列表，混合调用
        /// </summary>
        public DataTable ProductIndexPage()
        {
            Tag tag = this.Document.CurrentRenderingTag;
            //数据条数
            var topTag = tag.Attributes["top"];
            int top = MyCommFun.Obj2Int(topTag.Value.GetValue());
            //取类ＩＤ
           var classlayer = tag.Attributes["cid"];
           int classid =MyCommFun.Obj2Int(classlayer.Value.GetValue());
            //自定义where
           var whereTag = tag.Attributes["where"];
           string mywhere = MyCommFun.ObjToStr(whereTag.Value.GetValue());

           var orderByTag = tag.Attributes["orderby"];
           string orderby = MyCommFun.ObjToStr(orderByTag.Value.GetValue());
           string where = where = " wid=" + wid ;
            if (classid != 0) { 
           where+=" and categoryId="+classid;
           }

           where +=mywhere;

            DataSet productlist = new DataSet();
          

                DAL.wx_shop_product artDal = new DAL.wx_shop_product();
                productlist = artDal.GetList(top, where,orderby);
                if (productlist != null && productlist.Tables.Count > 0 && productlist.Tables[0].Rows.Count > 0)
                {
                    DataRow dr ;
                  
                    for (int i = 0; i < productlist.Tables[0].Rows.Count; i++)
                    {
                        dr = productlist.Tables[0].Rows[i];             
                        dr["link_url"] = MyCommFun.urlAddOpenid("detail.aspx?wid=" + wid + "&pid=" + dr["id"].ToString(), openid);                       
                        productlist.AcceptChanges();
                    }
                            
            }
           
            DataTable ds = new DataTable();
            ds = productlist.Tables[0].Copy();
            return ds;



        }
/// <summary>
/// 
/// </summary>
        public void ShopDetailPage()
        {
            BLL.wx_shop_product artDal = new BLL.wx_shop_product();
            int pid = MyCommFun.RequestInt("pid");
            Model.wx_shop_product product = artDal.GetModel(pid);
            if (product != null)
            {
                string skuStr = "{\"attr\":[";
                string availSkuStr = "{";
                if (product.skulist != null && product.skulist.Count > 0)
                {

                    //////////////////生成新的list对数据进行分类
                    List<int?> arrlist = new List<int?>();
                    for (int i = 0; i < product.skulist.Count; i++)
                    {
                        arrlist.Add(product.skulist[i].attributeId);
                    }
                    IList<int?> nlist = arrlist.Distinct().ToList();//去除重复值
                    //////////////////////
                    for (int j = 0; j < nlist.Count; j++)
                    {
                        //////////////////////////////////////
                        List<Model.wx_shop_sku> newskulist = new List<Model.wx_shop_sku>();
                        for (int i = 0; i < product.skulist.Count; i++)
                        {
                            if (product.skulist[i].attributeId == nlist[j].Value)
                            {
                                newskulist.Add(product.skulist[i]);
                            }
                        }

                        /////////////////////////////////////
                        string dh = "";
                        if (j == (nlist.Count - 1)) dh = ""; else dh = ",";

                        skuStr += "{\"attrname\":\"" + newskulist[j].attrName + "\",\"attrlist\": [";

                        string skuname = "";
                        for (int i = 0; i < newskulist.Count; i++)
                        {
                          string  addprice =newskulist[i].price.ToString();
                            newskulist[i].price += product.salePrice;
                        //    newskulist[i].price *= 100;
                            string dhi = "", dhk = ",";
                            if (i != (newskulist.Count - 1)) dhi = ","; else dhi = "";//availSkuStr
                            if (j == (nlist.Count - 1) && i == (newskulist.Count - 1)) dhk = "";

                            skuStr += "{ \"pid\": " + newskulist[i].id + ", \"aname\": \"" + newskulist[i].attributeValue + "\", \"addprice\": \"" + addprice + "\", \"stockPrice\": \"" + newskulist[i].price + "\", \"maketPrice\": \"" + product.marketPrice + "\" }" + dhi + " ";

                            //   skuStr += "{ \"attrname\": \"" + newskulist[i].attributeValue + "\", \"stockPrice\": \"" + newskulist[i].price + "\", \"maketPrice\": \"" + product.marketPrice * 100 + "\" }" + dhi + "";

                            availSkuStr += "\"" + newskulist[i].attrName + ":" + newskulist[i].attributeValue + "\": { \"pid\": " + newskulist[i].id + ", \"stockCount\": \"\", \"stockPrice\": \"" + newskulist[i].price + "\", \"maketPrice\": \"" + product.marketPrice * 100 + "\" }" + dhk + " ";

                            skuname = newskulist[i].attrName;

                        }
                        skuStr += "]}" + dh;
                    }

                    skuStr += "]}";
                    availSkuStr += "}";

                    //XCWeiXin.DAL.ShopSKUDal skuDal = new DAL.ShopSKUDal();
                    //IList<Model.ShopSKU> skulist = skuDal.SKUConvert(product.skulist);
                    //this.Document.SetValue("skulist", skulist[0]);
                }
                else {
                    skuStr += "]}";
                }

                if (availSkuStr == "{}")
                {
                    availSkuStr = "{ \"\": { \"pid\": 0, \"stockCount\": \"\", \"stockPrice\": \"" + product.salePrice + "\", \"maketPrice\": \"" + product.marketPrice * 100 + "\" } }";
                }
                this.Document.SetValue("skuStr", skuStr);
                this.Document.SetValue("availSkuStr", availSkuStr);
                this.Document.SetValue("model", product);
                //快递信息列表
                BLL.express expressBll = new BLL.express();
                DataSet dsExpress = expressBll.GetExpressList100(wid);
                this.Document.SetValue("express", dsExpress);

                //支付信息列表
                BLL.payment pbll = new BLL.payment();
                DataSet dsPay = pbll.GetList(0, "  is_lock=0 and wid=" + wid, "  sort_id asc");
                this.Document.SetValue("payment", dsPay);


            }
            
        }
        /// <summary>
        /// 获取类别列表
        /// </summary>
        /// <returns></returns>
        public DataTable getclasslist() {
            Tag tag = this.Document.CurrentRenderingTag;
            var parentidObj = tag.Attributes["parentid"];
            int parentid =0;           
                if (parentidObj != null && MyCommFun.isNumber(parentidObj.Value.GetValue()))
            {
                parentid = MyCommFun.Obj2Int(parentidObj.Value.GetValue());
            }
            var topNumObj = tag.Attributes["top"];
            int topNum = 0;
            if (topNumObj != null && MyCommFun.isNumber(topNumObj.Value.GetValue()))
            {
                topNum = MyCommFun.Obj2Int(topNumObj.Value.GetValue());
            }
            DAL.wx_shop_category classlist = new DAL.wx_shop_category();
            return classlist.GetWCodeList(wid, parentid,topNum);
        
        }

        /// <summary>
        /// 获得wid的用户分类信息 
        /// </summary>
        /// <returns></returns>
        public IList<Model.wx_shop_category> getCategory()
        {
           
            Tag tag = this.Document.CurrentRenderingTag;

            ///classlayer表示取类别深度，如果为-1，则取所有分类的深度，如果为1，则取第一层目录，如果为2，则去第2层目录
            var classlayer = tag.Attributes["classlayer"];
            var parentidObj = tag.Attributes["parentid"];
            int parentid = -1;
            if (parentidObj != null && MyCommFun.isNumber(parentidObj.Value.GetValue()))
            {
                parentid = MyCommFun.Obj2Int(parentidObj.Value.GetValue());
            }
            int class_layer = -1;
            if (classlayer != null && MyCommFun.isNumber(classlayer.Value.GetValue()))
            {
                class_layer = MyCommFun.Obj2Int(classlayer.Value.GetValue());
            }
            DAL.wx_shop_category cateBll = new DAL.wx_shop_category();
            IList<Model.wx_shop_category> categorylist = cateBll.GetCategoryListByWid(wid, -1, parentid, class_layer);
            if (categorylist != null && categorylist.Count > 0)
            {
                Model.wx_shop_category cat = new Model.wx_shop_category();
                for (int i = 0; i < categorylist.Count; i++)
                {
                    cat = categorylist[i];
                   
                    if (cat.link_url == null || cat.link_url.Trim() == "")
                    {  //如果link_url为空，则直接调用本系统的信息
                        cat.link_url = MyCommFun.urlAddOpenid("/shop/list.aspx?wid=" + wid + "&cid=" + cat.id, openid);
                        cat.category_url = MyCommFun.urlAddOpenid("/shop/category.aspx?wid=" + wid + "&cid=" + cat.id, openid);
                    }
                    else
                    {
                        cat.link_url = MyCommFun.urlAddOpenid(cat.link_url, openid);
                    }
                }
            }

            return categorylist;
        }
        /// <summary>
        /// 获得图片＝焦点图片 
        /// </summary>
        /// <returns></returns>
        public void getalbums()
        {

            Tag where = null;
            where = this.Document.GetChildTagById("mwhere");
            string whereStr = "";

            if (where != null)
            {
                whereStr = where.Attributes["value"].Value.ToString();
                int mwid = MyCommFun.RequestInt("wid");
                int mcid = MyCommFun.RequestInt("cid");
                int mpic = MyCommFun.RequestInt("pid");
                int sid = 0;
                //取settingＩＤ
                DAL.wx_shop_setting shopset = new DAL.wx_shop_setting();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  top 1 id from wx_shop_setting ");
                strSql.Append(" where wid=@wid");
                SqlParameter[] parameters = { new SqlParameter("@wid", SqlDbType.Int, 4) };
                parameters[0].Value = mwid;
                XCWeiXin.Model.wx_shop_setting model = new XCWeiXin.Model.wx_shop_setting();
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sid = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }



                string sqlwhere = "";
                switch (whereStr)
                {
                    case "shopsettingId":
                        sqlwhere = " shopsettingId=" + sid;
                        break;
                    case "classid":
                        sqlwhere = " classId=" + mcid;
                        break;
                    case "productId":
                        sqlwhere = " productId=" + mpic;
                        break;
                    default:
                        break;

                }

                DAL.wx_shop_albums cateBll = new DAL.wx_shop_albums();
                DataSet albumslist = cateBll.GetList(sqlwhere);
                if (albumslist != null && albumslist.Tables.Count > 0 && albumslist.Tables[0].Rows.Count > 0)
                {
                    DataRow dr;
                    for (int i = 0; i < albumslist.Tables.Count; i++)
                    {
                        dr = albumslist.Tables[0].Rows[i];
                        albumslist.AcceptChanges();

                    }
                }

                this.Document.SetValue("albumslist", albumslist);//文章列表
            }
        }
        /// <summary>
        /// 购物车页面
        /// </summary>
        public void CartDetailPage()
        {
            BLL.wx_shop_cart cartBll = new BLL.wx_shop_cart();
            IList<Model.cartProduct> cartList = cartBll.GetCartList(openid, wid);
            string cartStr = "{";
            if (cartList.Count > 0)
            {
                for (int i = cartList.Count - 1; i >=0; i--)
                {
                    cartList[i].fskuInfo = cartList[i].skuInfo.Replace("-", "　");
                    if (i != 0)
                    {
                        cartStr += "\"" + i  + "\": { \"ic\": \"" + cartList[i].id + "\", \"attr\": \"\", \"bc\": \"" + cartList[i].productNum + "\", \"mid\": " + cartList[i] .skuId+ " },";
                    }
                    else
                    {
                        cartStr += "\"" + i + "\": { \"ic\": \"" + cartList[i].id + "\", \"attr\": \"\", \"bc\": \"" + cartList[i].productNum + "\", \"mid\": " + cartList[i].skuId + " }";
                    }
                }
            }
            cartStr += "}";
            decimal alltotPrice = cartList.Sum(item => item.totPrice);
            this.Document.SetValue("cartlist", cartList);
            this.Document.SetValue("alltot", alltotPrice);
            this.Document.SetValue("cartStr", cartStr);

        }
        
        /// <summary>
        /// 修改地址的页面
        /// </summary>
        public void editAddrPage()
        {
            string frompage = MyCommFun.QueryString("frompage");
            this.Document.SetValue("frompage", frompage);
            BLL.wx_shop_user_addr uAddrBll = new BLL.wx_shop_user_addr();
            IList<Model.wx_shop_user_addr> uaddrList = uAddrBll.GetOpenidAddr(openid, wid);
            if (uaddrList == null || uaddrList.Count <= 0 || uaddrList[0].id <= 0)
            {

            }
            else
            {
                this.Document.SetValue("addrinfo", uaddrList[0]);
            }

        }
        /// <summary>
        /// 确认订单页面
        /// </summary>
        public void confirmOrder()
        {
            //1用户的地址
            BLL.wx_shop_user_addr uAddrBll = new BLL.wx_shop_user_addr();
            IList<Model.wx_shop_user_addr> uaddrList = uAddrBll.GetOpenidAddrName(openid, wid);
            if (uaddrList == null || uaddrList.Count <= 0 || uaddrList[0].id <= 0)
            { }
            else
            {
                this.Document.SetValue("addrinfo", uaddrList[0]);
            }

            //快递信息列表
            BLL.express expressBll = new BLL.express();
            DataSet dsExpress = expressBll.GetExpressList100(wid);
            this.Document.SetValue("express", dsExpress);

            //支付信息列表
            BLL.payment pbll = new BLL.payment();
            DataSet dsPay = pbll.GetList(0, "  is_lock=0 and wid=" + wid, "  sort_id asc");
            this.Document.SetValue("payment", dsPay);
            
            //购物车里的商品
            BLL.wx_shop_cart cartBll = new BLL.wx_shop_cart();
            IList<Model.cartProduct> cartList = cartBll.GetCartList(openid, wid);
            this.Document.SetValue("cartlist", cartList);

            string cartStr = "[";
            if (cartList.Count > 0)
            {
                for (int i = cartList.Count - 1; i >= 0; i--)
                {
                    if (i != 0)
                    {
                        cartStr += "{ \"ic\": \"" + cartList[i].id + "\", \"attr\": \"\", \"bc\": \"" + cartList[i].productNum + "\", \"mid\": " + cartList[i].skuId + " },";
                    }
                    else
                    {
                        cartStr += "{ \"ic\": \"" + cartList[i].id + "\", \"attr\": \"\", \"bc\": \"" + cartList[i].productNum + "\", \"mid\": " + cartList[i].skuId + " }";
                    }
                }
            }
            cartStr += "]";
            decimal alltotPrice = cartList.Sum(item => item.totPrice);
            
            this.Document.SetValue("alltot", alltotPrice);
            this.Document.SetValue("cartStr", cartStr);

        }

        /// <summary>
        /// 下单成功页面
        /// </summary>
        public void OrderSuccessPage()
        {
            BLL.orders oBll = new BLL.orders();
            int orderid = MyCommFun.RequestInt("orderid");
            Model.orders order = oBll.GetModel(orderid);
            if (order != null)
            {
                this.Document.SetValue("order", order);
            }
        }

        /// <summary>
        /// 用户中心
        /// </summary>
        public void userinfoPage()
        {
            BLL.orders oBll = new BLL.orders();
            //待付款的
            int wid = MyCommFun.RequestInt("wid");
            string openid = MyCommFun.RequestOpenid();
            IList<Model.orders> orderlist_dfu = oBll.GetModelList(" wid=" + wid + " and openid='" + openid + "'  and   payment_status=1 and status=1 order by id desc");//and payment_id in (2,3)
            if (orderlist_dfu != null)
            {
                for (int i = 0; i < orderlist_dfu.Count; i++)
                {
                    orderlist_dfu[i].status = GetOrderStatus_int(orderlist_dfu[i].status, orderlist_dfu[i].payment_status, orderlist_dfu[i].express_status);
                    orderlist_dfu[i].statusName = GetOrderStatus(orderlist_dfu[i].status, orderlist_dfu[i].payment_status, orderlist_dfu[i].express_status);

                }
                this.Document.SetValue("o_dfu", orderlist_dfu);
                this.Document.SetValue("dfk_num", orderlist_dfu.Count);
            }
           
            //待收货的
            IList<Model.orders> orderlist_dsh = oBll.GetModelList(" wid=" + wid + " and openid='" + openid + "' and  payment_status=2  and status =2 order by id desc");
            if (orderlist_dsh != null)
            {
                for (int i = 0; i < orderlist_dsh.Count; i++)
                {
                    orderlist_dsh[i].status = GetOrderStatus_int(orderlist_dsh[i].status, orderlist_dsh[i].payment_status, orderlist_dsh[i].express_status);
                    orderlist_dsh[i].statusName = GetOrderStatus(orderlist_dsh[i].status, orderlist_dsh[i].payment_status, orderlist_dsh[i].express_status);

                }

                this.Document.SetValue("o_dsh", orderlist_dsh);
                this.Document.SetValue("dsh_num", orderlist_dsh.Count);
            }

            //已结束的
            IList<Model.orders> orderlist_yjs = oBll.GetModelList(" wid=" + wid + " and openid='" + openid + "' and  payment_status=2 and status =6 order by id desc");
            if (orderlist_yjs != null)
            {
                for (int i = 0; i < orderlist_yjs.Count; i++)
                {
                    orderlist_yjs[i].status = GetOrderStatus_int(orderlist_yjs[i].status, orderlist_yjs[i].payment_status, orderlist_yjs[i].express_status);
                    orderlist_yjs[i].statusName = GetOrderStatus(orderlist_yjs[i].status, orderlist_yjs[i].payment_status, orderlist_yjs[i].express_status);
                }

                this.Document.SetValue("o_yjs", orderlist_yjs);
                this.Document.SetValue("yjs_num", orderlist_yjs.Count);
            }

        }

        /// <summary>
        /// 订单详情页面
        /// </summary>
        public void orderDetail()
        {
            int wid = MyCommFun.RequestInt("wid");
            string openid = MyCommFun.RequestOpenid();
            int orderId = MyCommFun.RequestInt("orderid");
            BLL.orders oBll = new BLL.orders();
            //Model.orders order = oBll.GetModel(orderId);
             IList<Model.orders> orderlist_detail = oBll.GetModelList(" id="+orderId);
             if (orderlist_detail != null)
             {
                 Model.orders order = orderlist_detail[0];
                 this.Document.SetValue("order", order);
                 string statusName = GetOrderStatus(order.status, order.payment_status, order.express_status);
                 this.Document.SetValue("statusName", statusName);

                 string paymentName = new XCWeiXin.BLL.payment().GetTitle(wid, order.payment_id);
                 this.Document.SetValue("paymentName", paymentName);
                 string expressName = new XCWeiXin.BLL.express().GetTitle(order.express_id);
                 this.Document.SetValue("expressName", expressName);


             }

        }


        #region 返回订单状态=============================
        protected string GetOrderStatus(int status, int payment_status, int express_status)
        {
           string  ret = "";
            
            switch (status)
            {
                case 1: //如果是线下支付，支付状态为0，如果是线上支付，支付成功后会自动改变订单状态为已确认
                    if (payment_status > 0)
                    {
                        ret = "待付款";
                    }
                    else
                    {
                        ret ="等待商户确认";
                    }
                    break;
                case 2: //如果订单为已确认状态，则进入发货状态
                    if (express_status > 1)
                    {
                        ret = "已发货";
                    }
                    else
                    {
                        ret = "待发货";
                    }
                    break;
                case 3:
                    ret = "待收货";
                    break;
                case 4:
                    ret = "已关闭";
                    break;
                case 5:
                    ret = "已作废";
                    break;
                case 6:
                    ret = "交易完成";
                    break;
            }

            return ret;
        }

      

        /// <summary>
        /// 订单状态，转化成与zepto.min.js里一致的
        /// </summary>
        /// <param name="status"></param>
        /// <param name="payment_status"></param>
        /// <param name="express_status"></param>
        /// <returns></returns>
        protected int  GetOrderStatus_int(int status, int payment_status, int express_status)
        {
            int ret = 0;
            
            switch (status)
            {
                case 1: //如果是线下支付，支付状态为0，如果是线上支付，支付成功后会自动改变订单状态为已确认
                    if (payment_status > 0)
                    {
                        ret = 1;
                    }
                    else
                    {
                        ret =14;
                    }
                    break;
                case 2: //如果订单为已确认状态，则进入发货状态
                    if (express_status > 1)
                    {
                        ret = 25;
                    }
                    else
                    {
                        ret = 2;
                    }
                    break;
                case 3:
                    ret = 6;
                    break;
                case 4:
                    ret = 4;
                    break;
                case 5:
                    ret = 26;
                    break;
            }

            return ret;
        }

        #endregion

        private int getCartCount() 
        {
            BLL.wx_shop_cart cartBll = new BLL.wx_shop_cart();
            int getcartcount = cartBll.GetRecordCount("wid=" + wid + " and openid='" + openid + "'");
            return getcartcount;
        }

        /// <summary>
        /// 单位 元*100
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        private object ComputeMoney(object[] news)
        {
            if (news.Length > 0 && news[0] != null)
            {
                decimal yuan = MyCommFun.Str2Decimal(news[0].ToString());
                yuan *= 100;
                return yuan;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 商城首页的url
        /// </summary>
        /// <returns></returns>
        private string indexUrl()
        {
            string url = "";
           // url = MyCommFun.getWebSite() + "/shop/index.aspx?wid=" + wid;
            url = MyCommFun.urlAddOpenid("/shop/index.aspx?wid=" + wid, openid);
            return url;
        }


        #endregion



        public DataSet productlist { get; set; }
    }
}
