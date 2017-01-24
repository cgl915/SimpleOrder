using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HF.PLM.Framework.Commons;
using HF.PLM.Pager.Entity;

namespace HF.PLM.Framework.EF
{
    ///// <summary>
    ///// 基于Web API接口的基础API包装类
    ///// </summary>
    ///// <typeparam name="T">Facade接口</typeparam>
    //public class BaseApiService<DTO, Entity> : IBaseService<DTO, Entity>
    //    where DTO : class
    //    where Entity : class
    //{
    //    #region 构造函数及变量属性

    //    /// <summary>
    //    /// 设置的接口访问签名信息（每次获取自动从缓存里面取）
    //    /// </summary>
    //    protected SignatureInfo SignatureInfo
    //    {
    //        get
    //        {
    //            //通过缓存获取签名对象信息
    //            return Cache.Instance["SignatureInfo"] as SignatureInfo;
    //        }
    //    }

    //    /// <summary>
    //    /// 访问网络的辅助类
    //    /// </summary>
    //    protected HttpHelper helper = new HttpHelper();

    //    /// <summary>
    //    /// 访问配置文件的辅助类
    //    /// </summary>
    //    protected AppConfig config = new AppConfig();

    //    /// <summary>
    //    /// WCF配置文件, 默认为"ApiConfig.config"
    //    /// </summary>
    //    private string configurationPath = "ApiConfig.config";

    //    /// <summary>
    //    /// 构建属性，方便在值变化的时候，重新设置AppConfig属性
    //    /// </summary>
    //    protected string ConfigurationPath
    //    {
    //        get { return configurationPath; }
    //        set
    //        {
    //            configurationPath = value;
    //            config = new AppConfig(value);
    //        }
    //    }

    //    /// <summary>
    //    /// API配置节点,在子类中配置
    //    /// </summary>
    //    protected string configurationName = "";

    //    /// <summary>
    //    /// 默认构造函数
    //    /// </summary>
    //    public BaseApiService()
    //    {
    //        helper.ContentType = "application/json";
    //    }

    //    /// <summary>
    //    /// 使用自定义配置
    //    /// </summary>
    //    /// <param name="configurationName">API配置项名称</param>
    //    /// <param name="configurationPath">配置路径</param>
    //    public BaseApiService(string configurationName, string configurationPath)
    //    {
    //        this.configurationName = configurationName;
    //        this.ConfigurationPath = configurationPath;//记得使用属性ConfigurationPath
    //    }

    //    #endregion

    //    #region URL签名的处理函数

    //    /// <summary>
    //    /// 根据当前时间和随机数，生成签名字符串的URL
    //    /// </summary>
    //    /// <param name="appId">应用ID</param>
    //    /// <param name="appSecret">渠道接入秘钥</param>
    //    /// <param name="token">访问令牌</param>
    //    protected string GetSignatureUrl(string appId, string appSecret, string token = null)
    //    {
    //        string timestamp = DateTime.Now.DateTimeToInt().ToString();
    //        string nonce = new Random().NextDouble().ToString();
    //        string signature = SignatureString(appSecret, timestamp, nonce);

    //        string result = string.Format("?signature={0}&timestamp={1}&nonce={2}&appid={3}", signature, timestamp, nonce, appId);
    //        if (!string.IsNullOrEmpty(token))
    //        {
    //            result += string.Format("&token={0}", token);
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 生成签名字符串的URL
    //    /// </summary>
    //    /// <param name="appId">应用ID</param>
    //    /// <param name="appSecret">渠道接入秘钥</param>
    //    /// <param name="timestamp">时间戳</param>
    //    /// <param name="nonce">随机数</param>
    //    protected string GetSignatureUrl(string appId, string appSecret, string timestamp, string nonce)
    //    {
    //        string signature = SignatureString(appSecret, timestamp, nonce);
    //        return string.Format("?signature={0}&timestamp={1}&nonce={2}&appid={3}", signature, timestamp, nonce, appId);
    //    }

    //    /// <summary>
    //    /// 生成签名字符串
    //    /// </summary>
    //    /// <param name="appSecret">渠道接入秘钥</param>
    //    /// <param name="timestamp">时间戳</param>
    //    /// <param name="nonce">随机数</param>
    //    protected string SignatureString(string appSecret, string timestamp, string nonce)
    //    {
    //        ArrayList ArrTmp = new ArrayList() { appSecret, timestamp, nonce };
    //        ArrTmp.Sort(new DictionarySort());

    //        string tmpStr = string.Join("", ArrTmp.ToArray());

    //        tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
    //        return tmpStr.ToLower();
    //    }

    //    /// <summary>
    //    /// 字典排序对比器
    //    /// </summary>
    //    public class DictionarySort : System.Collections.IComparer
    //    {
    //        /// <summary>
    //        /// 对比两个数值
    //        /// </summary>
    //        /// <returns></returns>
    //        public int Compare(object oLeft, object oRight)
    //        {
    //            string sLeft = oLeft as string;
    //            string sRight = oRight as string;
    //            int iLeftLength = sLeft.Length;
    //            int iRightLength = sRight.Length;
    //            int index = 0;
    //            while (index < iLeftLength && index < iRightLength)
    //            {
    //                if (sLeft[index] < sRight[index])
    //                    return -1;
    //                else if (sLeft[index] > sRight[index])
    //                    return 1;
    //                else
    //                    index++;
    //            }
    //            return iLeftLength - iRightLength;

    //        }
    //    }

    //    /// <summary>
    //    /// 组合URL和Action的内容
    //    /// </summary>
    //    /// <param name="url">api的URL，如http://localhost/api/</param>
    //    /// <param name="action">操作动作，如insert</param>
    //    /// <returns></returns>
    //    protected string CombindUrl(string url, string action)
    //    {
    //        string result = url;
    //        if (url.EndsWith("/") || url.EndsWith("\\"))
    //        {
    //            result += action;
    //        }
    //        else
    //        {
    //            result += "/" + action;
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 获取API的配置路径并检查
    //    /// </summary>
    //    /// <returns></returns>
    //    private string GetBaseUrl()
    //    {
    //        string baseUrl = config.AppConfigGet(this.configurationName);//配置的API控制器基础路径
    //        if (string.IsNullOrEmpty(baseUrl))
    //        {
    //            string error = string.Format("请检查配置WebAPI的文件【{0}】是否存在，或配置项【{1}】是否存在！", this.configurationPath, this.configurationName);
    //            LogTextHelper.Error(error);

    //            throw new ArgumentNullException(error);
    //        }
    //        return baseUrl;
    //    }

    //    /// <summary>
    //    /// 获取处理的URL，并带上具体的处理方法
    //    /// </summary>
    //    /// <param name="action">控制器方法名称</param>
    //    /// <returns></returns>
    //    protected string GetNormalUrl(string action)
    //    {
    //        string url = "";
    //        string baseUrl = GetBaseUrl();

    //        url = CombindUrl(baseUrl, action);//组合为完整的访问地址
    //        return url;
    //    }


    //    /// <summary>
    //    /// 获取处理的URL,不带Token信息，但是包含签名信息
    //    /// </summary>
    //    /// <param name="action">控制器方法名称</param>
    //    /// <returns></returns>
    //    protected string GetPostUrl(string action)
    //    {
    //        string url = "";
    //        if (this.SignatureInfo != null)
    //        {
    //            var append = GetSignatureUrl(SignatureInfo.appid, SignatureInfo.appsecret);

    //            string baseUrl = GetBaseUrl();
    //            url = CombindUrl(baseUrl, action + append);//组合为完整的访问地址
    //        }
    //        else
    //        {
    //            throw new ArgumentNullException("没有在缓存里面设置SignatureInfo签名信息");
    //        }
    //        return url;
    //    }

    //    /// <summary>
    //    /// 获取处理的URL,带Token和签名信息
    //    /// </summary>
    //    /// <param name="action">控制器方法名称</param>
    //    /// <returns></returns>
    //    protected string GetPostUrlWithToken(string action)
    //    {
    //        string url = "";
    //        if (this.SignatureInfo != null)
    //        {
    //            var append = GetSignatureUrl(SignatureInfo.appid, SignatureInfo.appsecret, SignatureInfo.token);

    //            string baseUrl = GetBaseUrl();
    //            url = CombindUrl(baseUrl, action + append);//组合为完整的访问地址
    //        }
    //        else
    //        {
    //            throw new ArgumentNullException("没有在缓存里面设置SignatureInfo签名信息");
    //        }
    //        return url;
    //    }

    //    /// <summary>
    //    /// 获取单纯包含token参数的连接
    //    /// </summary>
    //    /// <param name="action">控制器方法名称</param>
    //    /// <returns></returns>
    //    protected string GetTokenUrl(string action)
    //    {
    //        string url = "";
    //        if (this.SignatureInfo != null)
    //        {
    //            var append = string.Format("?token={0}", SignatureInfo.token);

    //            string baseUrl = GetBaseUrl();
    //            url = CombindUrl(baseUrl, action + append);//组合为完整的访问地址
    //        }
    //        else
    //        {
    //            throw new ArgumentNullException("没有在缓存里面设置SignatureInfo签名信息");
    //        }
    //        return url;
    //    }

    //    #endregion

    //    #region 对象添加、修改、查询接口

    //    /// <summary>
    //    /// 插入指定对象到数据库中
    //    /// </summary>
    //    /// <param name="obj">指定的对象</param>
    //    /// <returns>执行成功返回新增记录的自增长ID。</returns>
    //    public virtual bool Insert(DTO dto)
    //    {
    //        bool result = false;

    //        var action = "Insert";
    //        string url = GetPostUrlWithToken(action);
    //        Entity t = dto.MapTo<Entity>();
    //       var postData= JsonConvert.SerializeObject(t, Formatting.None);
            
    //        //var postData =obj.ToJson();

    //        CommonResult apiResult = JsonHelper<CommonResult>.ConvertJson(url, postData);
    //        if (apiResult != null)
    //        {
    //            result = apiResult.Success;
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 插入指定对象到数据库中
    //    /// </summary>
    //    /// <param name="obj">指定的对象</param>
    //    /// <returns>执行成功返回新增记录的自增长ID。</returns>
    //    public virtual int Insert2(DTO dto)
    //    {
    //        int result = -1;

    //        var action = "Insert2";
    //        string url = GetPostUrlWithToken(action);
    //        //var postData = obj.ToJson();
    //        Entity t = dto.MapTo<Entity>();
    //        var postData = JsonConvert.SerializeObject(t, Formatting.None);

    //        CommonResult apiResult = JsonHelper<CommonResult>.ConvertJson(url, postData);
    //        if (apiResult != null && !string.IsNullOrEmpty(apiResult.Data1))
    //        {
    //            result = apiResult.Data1.ToInt32();
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 插入或更新对象属性到数据库中
    //    /// </summary>
    //    /// <param name="obj">指定的对象</param>
    //    /// <param name="primaryKeyValue">主键的值</param>
    //    /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
    //    public virtual bool InsertUpdate(DTO dto, object primaryKeyValue)
    //    {
    //        bool result = false;

    //        var action = "InsertUpdate";
    //        string url = GetPostUrlWithToken(action) + string.Format("&id={0}", primaryKeyValue);
    //        //var postData = obj.ToJson();
    //        Entity t = dto.MapTo<Entity>();
    //        var postData = JsonConvert.SerializeObject(t, Formatting.None);

    //        CommonResult apiResult = JsonHelper<CommonResult>.ConvertJson(url, postData);
    //        if (apiResult != null)
    //        {
    //            result = apiResult.Success;
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 如果不存在记录，则插入对象属性到数据库中
    //    /// </summary>
    //    /// <param name="obj">指定的对象</param>
    //    /// <param name="primaryKeyValue">主键的值</param>
    //    /// <returns>执行插入成功返回<c>true</c>，否则为<c>false</c>。</returns>
    //    public virtual bool InsertIfNew(DTO dto, object primaryKeyValue)
    //    {
    //        bool result = false;

    //        var action = "InsertIfNew";
    //        string url = GetPostUrlWithToken(action) + string.Format("&id={0}", primaryKeyValue);
    //        //var postData = obj.ToJson();
    //        Entity t = dto.MapTo<Entity>();
    //        var postData = JsonConvert.SerializeObject(t, Formatting.None);

    //        CommonResult apiResult = JsonHelper<CommonResult>.ConvertJson(url, postData);
    //        if (apiResult != null)
    //        {
    //            result = apiResult.Success;
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 更新对象属性到数据库中
    //    /// </summary>
    //    /// <param name="obj">指定的对象</param>
    //    /// <param name="primaryKeyValue">主键的值</param>
    //    /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
    //    public virtual bool Update(DTO dto, object primaryKeyValue)
    //    {
    //        bool result = false;

    //        var action = "Update";
    //        string url = GetPostUrlWithToken(action) + string.Format("&id={0}", primaryKeyValue);
    //        //var postData = obj.ToJson();
    //        Entity t = dto.MapTo<Entity>();
    //        var postData = JsonConvert.SerializeObject(t, Formatting.None);
    //        CommonResult apiResult = JsonHelper<CommonResult>.ConvertJson(url, postData);
    //        if (apiResult != null)
    //        {
    //            result = apiResult.Success;
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 执行SQL查询语句，返回查询结果的所有记录的第一个字段,用逗号分隔。
    //    /// </summary>
    //    /// <param name="sql">SQL语句</param>
    //    /// <returns>
    //    /// 返回查询结果的所有记录的第一个字段,用逗号分隔。
    //    /// </returns>
    //    public virtual string SqlValueList(string sql)
    //    {
    //        string result = "";

    //        var action = "SqlValueList";
    //        string url = GetPostUrl(action);
    //        //var postData = new
    //        //{
    //        //    sql = sql
    //        //}.ToJson();

    //        //Entity t = dto.MapTo<Entity>();
    //        var postData = JsonConvert.SerializeObject(sql, Formatting.None);

    //        string content = helper.GetHtml(url, postData, true);
    //        if (!content.Contains("errcode"))
    //        {
    //            result = content;
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 执行SQL查询语句，返回所有记录的DataTable集合。
    //    /// </summary>
    //    /// <param name="sql">SQL查询语句</param>
    //    /// <returns></returns>
    //    public virtual DataTable SqlTable(string sql)
    //    {
    //        var action = "SqlTable";
    //        string url = GetPostUrl(action);
    //        //var postData = new
    //        //{
    //        //    sql = sql
    //        //}.ToJson();

    //        //Entity t = dto.MapTo<Entity>();
    //        var postData = JsonConvert.SerializeObject(sql, Formatting.None);

    //        DataTable apiResult = JsonHelper<DataTable>.ConvertJson(url, postData);
    //        return apiResult;
    //    }

    //    /// <summary>
    //    /// 查询数据库,检查是否存在指定ID的对象(用于字符型主键)
    //    /// </summary>
    //    /// <param name="key">对象的ID值</param>
    //    /// <returns>存在则返回指定的对象,否则返回Null</returns>
    //    public virtual DTO FindByID(string key)
    //    {
    //        var action = "FindByID";
    //        string url = GetTokenUrl(action) + string.Format("&id={0}", key);
    //       ;

    //       return JsonHelper<Entity>.ConvertJson(url).MapTo<DTO>();
    //    }

    //    /// <summary>
    //    /// 查询数据库,检查是否存在指定ID的对象(用于整型主键)
    //    /// </summary>
    //    /// <param name="key">对象的ID值</param>
    //    /// <returns>存在则返回指定的对象,否则返回Null</returns>
    //    public virtual DTO FindByID2(int key)
    //    {
    //        var action = "FindByID2";
    //        string url = GetTokenUrl(action) + string.Format("&id={0}", key);
    //        return JsonHelper<Entity>.ConvertJson(url).MapTo<DTO>();
    //    }

    //    /// <summary>
    //    /// 根据条件查询数据库,如果存在返回第一个对象
    //    /// </summary>
    //    /// <param name="condition">查询的条件</param>
    //    /// <returns>指定的对象</returns>
    //    public virtual DTO FindSingle(string condition)
    //    {
    //        var action = "FindSingle";
    //        string url = GetTokenUrl(action) + string.Format("&condition={0}", condition);

    //        return JsonHelper<Entity>.ConvertJson(url).MapTo<DTO>();
    //    }

    //    /// <summary>
    //    /// 根据条件查询数据库,如果存在返回第一个对象
    //    /// </summary>
    //    /// <param name="condition">查询的条件</param>
    //    /// <param name="orderBy">排序条件</param>
    //    /// <returns>指定的对象</returns>
    //    public virtual DTO FindSingle2(string condition, string orderBy)
    //    {
    //        var action = "FindSingle2";
    //        string url = GetTokenUrl(action) + string.Format("&condition={0}&orderBy={1}", condition, orderBy);

    //        return JsonHelper<Entity>.ConvertJson(url).MapTo<DTO>();
    //    }

    //    /// <summary>
    //    /// 查找记录表中最旧的一条记录
    //    /// </summary>
    //    /// <returns></returns>
    //    public virtual DTO FindFirst()
    //    {
    //        var action = "FindFirst";
    //        string url = GetTokenUrl(action);

    //        return JsonHelper<Entity>.ConvertJson(url).MapTo<DTO>();
    //    }

    //    /// <summary>
    //    /// 查找记录表中最新的一条记录
    //    /// </summary>
    //    /// <returns></returns>
    //    public virtual DTO FindLast()
    //    {
    //        var action = "FindLast";
    //        string url = GetTokenUrl(action);

    //        return JsonHelper<Entity>.ConvertJson(url).MapTo<DTO>();
    //    }

    //    #endregion

    //    #region 返回集合的接口

    //    /// <summary>
    //    /// 根据ID字符串(逗号分隔)获取对象列表
    //    /// </summary>
    //    /// <param name="idString">ID字符串(逗号分隔)</param>
    //    /// <returns>符合条件的对象列表</returns>
    //    public virtual List<DTO> FindByIDs(string idString)
    //    {
    //        var action = "FindByIDs";
    //        string url = GetTokenUrl(action) + string.Format("&idString={0}", idString);

    //        return JsonHelper<List<Entity>>.ConvertJson(url).MapToList<DTO>();
    //    }

    //    /// <summary>
    //    /// 根据条件查询数据库,并返回对象集合
    //    /// </summary>
    //    /// <param name="condition">查询的条件</param>
    //    /// <returns>指定对象的集合</returns>
    //    public virtual List<DTO> Find(string condition)
    //    {
    //        var action = "Find";
    //        string url = GetTokenUrl(action) + string.Format("&condition={0}", condition);

    //        return JsonHelper<List<Entity>>.ConvertJson(url).MapToList<DTO>();
    //    }

    //    /// <summary>
    //    /// 根据条件查询数据库,并返回对象集合
    //    /// </summary>
    //    /// <param name="condition">查询的条件</param>
    //    /// <param name="orderBy">排序条件</param>
    //    /// <returns>指定对象的集合</returns>
    //    public virtual List<DTO> Find2(string condition, string orderBy)
    //    {
    //        var action = "Find2";
    //        string url = GetTokenUrl(action) + string.Format("&condition={0}&orderBy={1}", condition, orderBy);

    //        return JsonHelper<List<Entity>>.ConvertJson(url).MapToList<DTO>();
    //    }

    //    /// <summary>
    //    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    //    /// </summary>
    //    /// <param name="condition">查询的条件</param>
    //    /// <param name="pagerInfo">分页实体</param>
    //    /// <returns>指定对象的集合</returns>
    //    public virtual List<DTO> FindWithPager(string condition, ref PagerInfo pagerInfo)
    //    {
    //        var action = "FindWithPager";
    //        string url = GetTokenUrl(action) + string.Format("&condition={0}", condition);
    //        //var postData = pagerInfo.ToJson();

    //        var postData = JsonConvert.SerializeObject(pagerInfo, Formatting.None);

    //        List<DTO> result = new List<DTO>();
    //        PagedList<Entity> list = JsonHelper<PagedList<Entity>>.ConvertJson(url, postData);
    //        if (list != null)
    //        {
    //            pagerInfo.RecordCount = list.total_count;//修改总记录数
    //            result = list.list.MapToList<DTO>();
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    //    /// </summary>
    //    /// <param name="condition">查询的条件</param>
    //    /// <param name="pagerInfo">分页实体</param>
    //    /// <param name="fieldToSort">排序字段</param>
    //    /// <returns>指定对象的集合</returns>
    //    public virtual List<DTO> FindWithPager2(string condition, ref PagerInfo pagerInfo, string fieldToSort)
    //    {
    //        var action = "FindWithPager2";
    //        string url = GetTokenUrl(action) + string.Format("&condition={0}&fieldToSort={1}", condition, fieldToSort);
    //        //var postData = pagerInfo.ToJson();
    //        var postData = JsonConvert.SerializeObject(pagerInfo, Formatting.None);

    //        List<DTO> result = new List<DTO>();
    //        PagedList<Entity> list = JsonHelper<PagedList<Entity>>.ConvertJson(url, postData);
    //        if (list != null)
    //        {
    //            pagerInfo.RecordCount = list.total_count;//修改总记录数
    //            result = list.list.MapToList<DTO>();
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    //    /// </summary>
    //    /// <param name="condition">查询的条件</param>
    //    /// <param name="pagerInfo">分页实体</param>
    //    /// <param name="fieldToSort">排序字段</param>
    //    /// <param name="desc">是否降序</param>
    //    /// <returns>指定对象的集合</returns>
    //    public virtual List<DTO> FindWithPager3(string condition, ref PagerInfo pagerInfo, string fieldToSort, bool desc)
    //    {
    //        var action = "FindWithPager3";
    //        string url = GetTokenUrl(action) + string.Format("&condition={0}&fieldToSort={1}&desc={2}", condition, fieldToSort, desc);
    //        //var postData = pagerInfo.ToJson();
    //        var postData = JsonConvert.SerializeObject(pagerInfo, Formatting.None);

    //        List<DTO> result = new List<DTO>();
    //        PagedList<Entity> list = JsonHelper<PagedList<Entity>>.ConvertJson(url, postData);
    //        if (list != null)
    //        {
    //            pagerInfo.RecordCount = list.total_count;//修改总记录数
    //            result = list.list.MapToList<DTO>();
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 返回数据库所有的对象集合
    //    /// </summary>
    //    /// <returns>指定对象的集合</returns>
    //    public virtual List<DTO> GetAll()
    //    {
    //        var action = "GetAll";
    //        string url = GetTokenUrl(action);


    //        return JsonHelper<List<Entity>>.ConvertJson(url).MapToList<DTO>();
    //    }

    //    /// <summary>
    //    /// 返回数据库所有的对象集合
    //    /// </summary>
    //    /// <param name="orderBy">自定义排序语句，如Order By Name Desc；如不指定，则使用默认排序</param>
    //    /// <returns>指定对象的集合</returns>
    //    public virtual List<DTO> GetAll2(string orderBy)
    //    {
    //        var action = "GetAll";
    //        string url = GetTokenUrl(action) + string.Format("&orderBy={0}", orderBy);

    //        return JsonHelper<List<Entity>>.ConvertJson(url).MapToList<DTO>();
    //    }

    //    /// <summary>
    //    /// 返回数据库所有的对象集合(用于分页数据显示)
    //    /// </summary>
    //    /// <param name="pagerInfo">分页实体信息</param>
    //    /// <returns>指定对象的集合</returns>
    //    public virtual List<DTO> GetAllWithPager(ref PagerInfo pagerInfo)
    //    {
    //        var action = "GetAllWithPager";
    //        string url = GetTokenUrl(action);
    //        //var postData = pagerInfo.ToJson();
    //        var postData = JsonConvert.SerializeObject(pagerInfo, Formatting.None);

    //        List<DTO> result = new List<DTO>();
    //        PagedList<Entity> list = JsonHelper<PagedList<Entity>>.ConvertJson(url, postData);
    //        if (list != null)
    //        {
    //            pagerInfo.RecordCount = list.total_count;//修改总记录数
    //            result = list.list.MapToList<DTO>();
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 返回数据库所有的对象集合(用于分页数据显示)
    //    /// </summary>
    //    /// <param name="pagerInfo">分页实体信息</param>
    //    /// <param name="fieldToSort">排序字段</param>
    //    /// <param name="desc">是否降序</param>
    //    /// <returns>指定对象的集合</returns>
    //    public virtual List<DTO> GetAllWithPager2(ref PagerInfo pagerInfo, string fieldToSort, bool desc)
    //    {
    //        var action = "GetAllWithPager2";
    //        string url = GetTokenUrl(action) + string.Format("&fieldToSort={0}&desc={1}", fieldToSort, desc);
    //        //var postData = pagerInfo.ToJson();
    //        var postData = JsonConvert.SerializeObject(pagerInfo, Formatting.None);

    //        List<DTO> result = new List<DTO>();
    //        PagedList<Entity> list = JsonHelper<PagedList<Entity>>.ConvertJson(url, postData);
    //        if (list != null)
    //        {
    //            pagerInfo.RecordCount = list.total_count;//修改总记录数
    //            result = list.list.MapToList<DTO>();
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 返回所有记录到DataTable集合中
    //    /// </summary>
    //    /// <returns></returns>
    //    public virtual DataTable GetAllToDataTable()
    //    {
    //        var action = "GetAllToDataTable";
    //        string url = GetTokenUrl(action);

    //        return JsonHelper<DataTable>.ConvertJson(url);
    //    }

    //    /// <summary>
    //    /// 返回所有记录到DataTable集合中
    //    /// </summary>
    //    /// <param name="orderBy">自定义排序语句，如Order By Name Desc；如不指定，则使用默认排序</param>
    //    /// <returns></returns>
    //    public virtual DataTable GetAllToDataTable2(string orderBy)
    //    {
    //        var action = "GetAllToDataTable2";
    //        string url = GetTokenUrl(action) + string.Format("&orderBy={0}", orderBy);

    //        return JsonHelper<DataTable>.ConvertJson(url);
    //    }

    //    /// <summary>
    //    /// 根据分页条件，返回DataSet对象
    //    /// </summary>
    //    /// <param name="pagerInfo">分页条件</param>
    //    /// <returns></returns>
    //    public virtual DataTable GetAllToDataTableWithPager(ref PagerInfo pagerInfo)
    //    {
    //        var action = "GetAllToDataTableWithPager";
    //        string url = GetTokenUrl(action);
    //        //var postData = pagerInfo.ToJson();
    //        var postData = JsonConvert.SerializeObject(pagerInfo, Formatting.None);

    //        DataTable result = new DataTable();
    //        PageTableList list = JsonHelper<PageTableList>.ConvertJson(url, postData);
    //        if (list != null)
    //        {
    //            pagerInfo.RecordCount = list.total_count;//修改总记录数
    //            result = list.list;
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 根据分页条件，返回DataSet对象
    //    /// </summary>
    //    /// <param name="pagerInfo">分页条件</param>
    //    /// <param name="fieldToSort">排序字段</param>
    //    /// <param name="desc">是否降序</param>
    //    /// <returns></returns>
    //    public virtual DataTable GetAllToDataTableWithPager2(ref PagerInfo pagerInfo, string fieldToSort, bool desc)
    //    {
    //        var action = "GetAllToDataTableWithPager2";
    //        string url = GetTokenUrl(action) + string.Format("&fieldToSort={0}&desc={1}", fieldToSort, desc);
    //        //var postData = pagerInfo.ToJson();
    //        var postData = JsonConvert.SerializeObject(pagerInfo, Formatting.None);

    //        DataTable result = new DataTable();
    //        PageTableList list = JsonHelper<PageTableList>.ConvertJson(url, postData);
    //        if (list != null)
    //        {
    //            pagerInfo.RecordCount = list.total_count;//修改总记录数
    //            result = list.list;
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 根据查询条件，返回记录到DataTable集合中
    //    /// </summary>
    //    /// <param name="condition">查询条件</param>
    //    /// <returns></returns>
    //    public virtual DataTable FindToDataTable(string condition)
    //    {
    //        var action = "FindToDataTable";
    //        string url = GetTokenUrl(action) + string.Format("&condition={0}", condition);

    //        return JsonHelper<DataTable>.ConvertJson(url);
    //    }

    //    /// <summary>
    //    /// 根据查询条件，返回记录到DataTable集合中
    //    /// </summary>
    //    /// <param name="condition">查询条件</param>
    //    /// <param name="pagerInfo">分页条件</param>
    //    /// <returns></returns>
    //    public virtual DataTable FindToDataTableWithPager(string condition, ref PagerInfo pagerInfo)
    //    {
    //        var action = "FindToDataTableWithPager" + string.Format("&condition={0}", condition);
    //        string url = GetTokenUrl(action);
    //        //var postData = pagerInfo.ToJson();
    //        var postData = JsonConvert.SerializeObject(pagerInfo, Formatting.None);

    //        DataTable result = new DataTable();
    //        PageTableList list = JsonHelper<PageTableList>.ConvertJson(url, postData);
    //        if (list != null)
    //        {
    //            pagerInfo.RecordCount = list.total_count;//修改总记录数
    //            result = list.list;
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 根据条件查询数据库,并返回DataTable集合(用于分页数据显示)
    //    /// </summary>
    //    /// <param name="condition">查询的条件</param>
    //    /// <param name="pagerInfo">分页实体</param>
    //    /// <param name="fieldToSort">排序字段</param>
    //    /// <param name="desc">是否降序</param>
    //    /// <returns>指定DataTable的集合</returns>
    //    public virtual DataTable FindToDataTableWithPager2(string condition, ref PagerInfo pagerInfo, string fieldToSort, bool desc)
    //    {
    //        var action = "FindToDataTableWithPager2";
    //        string url = GetTokenUrl(action) + string.Format("&fieldToSort={0}&desc={1}&condition={2}", fieldToSort, desc, condition);
    //        //var postData = pagerInfo.ToJson();
    //        var postData = JsonConvert.SerializeObject(pagerInfo, Formatting.None);

    //        DataTable result = new DataTable();
    //        PageTableList list = JsonHelper<PageTableList>.ConvertJson(url, postData);
    //        if (list != null)
    //        {
    //            pagerInfo.RecordCount = list.total_count;//修改总记录数
    //            result = list.list;
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// 根据条件，从视图里面获取记录
    //    /// </summary>
    //    /// <param name="viewName">视图名称</param>
    //    /// <param name="condition">查询条件</param>
    //    /// <returns></returns>
    //    public virtual DataTable FindByView(string viewName, string condition)
    //    {
    //        var action = "FindByView";
    //        string url = GetTokenUrl(action) + string.Format("&condition={0}&viewName={1}", condition, viewName);

    //        return JsonHelper<DataTable>.ConvertJson(url);
    //    }

    //    /// <summary>
    //    /// 根据条件，从视图里面获取记录
    //    /// </summary>
    //    /// <param name="viewName">视图名称</param>
    //    /// <param name="condition">查询条件</param>
    //    /// <param name="sortField">排序字段</param>
    //    /// <param name="isDescending">是否为降序</param>
    //    /// <returns></returns>
    //    public virtual DataTable FindByView2(string viewName, string condition, string sortField, bool isDescending)
    //    {
    //        var action = "FindByView2";
    //        string url = GetTokenUrl(action) + string.Format("&condition={0}&viewName={1}&sortField={2}&isDescending={3}", condition, viewName, sortField, isDescending);

    //        return JsonHelper<DataTable>.ConvertJson(url);
    //    }

    //    /// <summary>
    //    /// 根据条件，从视图里面获取记录
    //    /// </summary>
    //    /// <param name="viewName">视图名称</param>
    //    /// <param name="condition">查询条件</param>
    //    /// <param name="sortField">排序字段</param>
    //    /// <param name="isDescending">是否为降序</param>
    //    /// <param name="pagerInfo">分页条件</param>
    //    /// <returns></returns>
    //    public virtual DataTable FindByViewWithPager(string viewName, string condition, string sortField, bool isDescending, PagerInfo pagerInfo)
    //    {
    //        var action = "FindByViewWithPager";
    //        string url = GetTokenUrl(action) + string.Format("&viewName={0}&condition={1}&sortField={2}&isDescending={3}", viewName, condition, sortField, isDescending);
    //        //var postData = pagerInfo.ToJson();
    //        var postData = JsonConvert.SerializeObject(pagerInfo, Formatting.None);

    //        DataTable result = new DataTable();
    //        PageTableList list = JsonHelper<PageTableList>.ConvertJson(url, postData);
    //        if (list != null)
    //        {
    //            pagerInfo.RecordCount = list.total_count;//修改总记录数
    //            result = list.list;
    //        }
    //        return result;
    //    }

    //    #endregion

    //    #region 基础接口

    //    /// <summary>
    //    /// 获取表的所有记录数量
    //    /// </summary>
    //    /// <returns></returns>
    //    public int GetRecordCount2(string condition)
    //    {
    //        var action = "GetRecordCount2";
    //        string url = GetTokenUrl(action) + string.Format("&condition={0}", condition);

    //        return JsonHelper<DataTable>.ConvertString(url).ToInt32();
    //    }

    //    /// <summary>
    //    /// 获取表的所有记录数量
    //    /// </summary>
    //    /// <returns></returns>
    //    public int GetRecordCount()
    //    {
    //        var action = "GetRecordCount";
    //        string url = GetTokenUrl(action);

    //        return JsonHelper<DataTable>.ConvertString(url).ToInt32();
    //    }

    //    /// <summary>
    //    /// 查询数据库,检查是否存在指定键值的对象
    //    /// </summary>
    //    /// <param name="fieldName">指定的属性名</param>
    //    /// <param name="key">指定的值</param>
    //    /// <returns>存在则返回<c>true</c>，否则为<c>false</c>。</returns>
    //    public virtual bool IsExistKey(string fieldName, object key)
    //    {
    //        var action = "IsExistKey";
    //        string url = GetTokenUrl(action) + string.Format("&fieldName={0}&key={1}", fieldName, key);

    //        CommonResult result = JsonHelper<CommonResult>.ConvertJson(url);
    //        return (result != null) ? result.Success : false;
    //    }

    //    /// <summary>
    //    /// 根据condition条件，判断是否存在记录
    //    /// </summary>
    //    /// <param name="condition">查询的条件</param>
    //    /// <returns>如果存在返回True，否则False</returns>
    //    public virtual bool IsExistRecord(string condition)
    //    {
    //        var action = "IsExistRecord";
    //        string url = GetTokenUrl(action) + string.Format("&condition={0}", condition);

    //        CommonResult result = JsonHelper<CommonResult>.ConvertJson(url);
    //        return (result != null) ? result.Success : false;
    //    }

    //    /// <summary>
    //    /// 根据指定对象的ID,从数据库中删除指定对象(用于字符型主键)
    //    /// </summary>
    //    /// <param name="key">指定对象的ID</param>
    //    /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
    //    public virtual bool Delete(string key)
    //    {
    //        var action = "Delete";
    //        string url = GetPostUrlWithToken(action);
    //        //var postData = new
    //        //{
    //        //    id = key
    //        //}.ToJson();
    //        var postData = JsonConvert.SerializeObject(key, Formatting.None);

    //        CommonResult result = JsonHelper<CommonResult>.ConvertJson(url, postData);
    //        return (result != null) ? result.Success : false;
    //    }

    //    /// <summary>
    //    /// 根据指定对象的ID,从数据库中删除指定对象(用于整型主键)
    //    /// </summary>
    //    /// <param name="key">指定对象的ID</param>
    //    /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
    //    public virtual bool Delete2(int key)
    //    {
    //        var action = "Delete2";
    //        string url = GetPostUrlWithToken(action);
    //        //var postData = new
    //        //{
    //        //    id = key
    //        //}.ToJson();
    //        var postData = JsonConvert.SerializeObject(key, Formatting.None);
    //        CommonResult result = JsonHelper<CommonResult>.ConvertJson(url, postData);
    //        return (result != null) ? result.Success : false;
    //    }

    //    /// <summary>
    //    /// 删除多个ID的记录
    //    /// </summary>
    //    /// <param name="ids">多个id组合，逗号分开（1,2,3,4,5）</param>
    //    /// <returns></returns>
    //    public virtual bool DeleteByIds(string ids)
    //    {
    //        var action = "DeleteByIds";
    //        string url = GetPostUrlWithToken(action);
    //        //var postData = new
    //        //{
    //        //    ids = ids
    //        //}.ToJson();
    //        var postData = JsonConvert.SerializeObject(ids, Formatting.None);
    //        CommonResult result = JsonHelper<CommonResult>.ConvertJson(url, postData);
    //        return (result != null) ? result.Success : false;
    //    }

    //    /// <summary>
    //    /// 根据指定条件,从数据库中删除指定对象
    //    /// </summary>
    //    /// <param name="condition">删除记录的条件语句</param>
    //    /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
    //    public virtual bool DeleteByCondition(string condition)
    //    {
    //        var action = "DeleteByCondition";
    //        //var postData = new
    //        //{
    //        //    condition = condition
    //        //}.ToJson();
    //        var postData = JsonConvert.SerializeObject(condition, Formatting.None);
    //        string url = GetPostUrlWithToken(action);

    //        CommonResult result = JsonHelper<CommonResult>.ConvertJson(url, postData);
    //        return (result != null) ? result.Success : false;
    //    }
    //    #endregion

    //    #region 辅助型接口

    //    /// <summary>
    //    /// 获取字段列表
    //    /// </summary>
    //    /// <param name="fieldName">字段名称</param>
    //    /// <returns></returns>
    //    public virtual List<string> GetFieldList(string fieldName)
    //    {
    //        var action = "GetFieldList";
    //        string url = GetTokenUrl(action) + string.Format("&fieldName={0}", fieldName);

    //        List<string> result = JsonHelper<List<string>>.ConvertJson(url);
    //        return result;
    //    }

    //    /// <summary>
    //    /// 根据条件，获取某字段数据字典列表
    //    /// </summary>
    //    /// <param name="fieldName">字段名称</param>
    //    /// <param name="condition">查询的条件</param>
    //    /// <returns></returns>
    //    public virtual List<string> GetFieldListByCondition(string fieldName, string condition)
    //    {
    //        var action = "GetFieldListByCondition";
    //        string url = GetTokenUrl(action) + string.Format("&fieldName={0}&condition={1}", fieldName, condition);

    //        List<string> result = JsonHelper<List<string>>.ConvertJson(url);
    //        return result;
    //    }

    //    /// <summary>
    //    /// 获取表的字段名称和数据类型列表。
    //    /// </summary>
    //    /// <returns></returns>
    //    public virtual DataTable GetFieldTypeList()
    //    {
    //        var action = "GetFieldTypeList";
    //        string url = GetTokenUrl(action);

    //        DataTable result = JsonHelper<DataTable>.ConvertJson(url);
    //        return result;
    //    }

    //    /// <summary>
    //    /// 获取字段中文别名（用于界面显示）的字典集合
    //    /// </summary>
    //    /// <returns></returns>
    //    public virtual Dictionary<string, string> GetColumnNameAlias()
    //    {
    //        var action = "GetColumnNameAlias";
    //        string url = GetTokenUrl(action);

    //        Dictionary<string, string> result = JsonHelper<Dictionary<string, string>>.ConvertJson(url);
    //        return result;
    //    }

    //    /// <summary>
    //    /// 获取指定字段的报表数据
    //    /// </summary>
    //    /// <param name="fieldName">表字段</param>
    //    /// <param name="condition">查询条件</param>
    //    /// <returns></returns>
    //    public virtual DataTable GetReportData(string fieldName, string condition)
    //    {
    //        var action = "GetColumnNameAlias";
    //        string url = GetTokenUrl(action) + string.Format("&fieldName={0}&condition={1}", fieldName, condition);

    //        DataTable result = JsonHelper<DataTable>.ConvertJson(url);
    //        return result;
    //    }

    //    #endregion
    //}
}
