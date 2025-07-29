using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI;

public interface IRestApiService
{
    /// <summary>
    /// Отправить запрос Get
    /// </summary>
    /// <param name="requestURL">URL запроса</param>
    /// <returns></returns>
    Task<string> Get(string requestURL);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="requestUrl">URL запроса</param>
    /// <param name="requestBody">Тело запроса</param>
    /// <returns></returns>
    Task<string> Post(string requestUrl, HttpContent requestBody);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="requestUrl">URL запроса</param>
    /// <returns></returns>
    Task<string> Delete(string requestUrl);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="requestUrl">URL запроса</param>
    /// <param name="requestBody">Тело запроса</param>
    /// <returns></returns>
    Task<string> Put(string requestUrl, HttpContent requestBody);
}
