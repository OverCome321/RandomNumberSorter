using System.Text.Json;
using System.Text;

namespace ApiService
{
    /// <summary>
    /// Класс для отправки данных на сервер.
    /// </summary>
    public static class ApiHelper
    {
        /// <summary>
        /// Отправка данных на REST API сервер. (Сервера нет, так что обработки ответа нет)
        /// </summary>
        /// <param name="url">URL сервера.</param>
        /// <param name="data">Данные для отправки.</param>
        public static async Task SendDataToServer(string url, List<int> data)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonData = JsonSerializer.Serialize(data);
                    using (StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json"))
                    {
                        HttpResponseMessage response = await client.PostAsync(url, content);

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Данные успешно отправлены на сервер.");
                        }
                        else
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            Console.WriteLine($"Ошибка при отправке данных на сервер. Статус: {(int)response.StatusCode} {response.StatusCode}.");

                            if (!string.IsNullOrEmpty(responseContent))
                            {
                                Console.WriteLine($"Сообщение сервера: {responseContent}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Пример метода с JWT авторизацией и взаимодействием с API.
        /// </summary>
        /// <param name="url">URL сервера.</param>
        /// <param name="data">Данные для отправки.</param>
        /// <param name="jwtToken">Токен авторизации.</param>
        /// <returns>Ответ от сервера в виде строки.</returns>
        //public static async Task<string> SendDataWithJwtAsync(string url, List<int> data, string jwtToken)
        //{
        //    try
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            Добавление JWT токена в заголовок
        //            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);

        //            string jsonData = JsonSerializer.Serialize(data);
        //            using (StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json"))
        //            {
        //                HttpResponseMessage response = await client.PostAsync(url, content);

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    Console.WriteLine("Данные успешно отправлены на сервер с JWT авторизацией.");
        //                    return await response.Content.ReadAsStringAsync();
        //                }
        //                else
        //                {
        //                    string responseContent = await response.Content.ReadAsStringAsync();
        //                    Console.WriteLine($"Ошибка при отправке данных на сервер с JWT авторизацией. Статус: {(int)response.StatusCode} {response.StatusCode}.");

        //                    if (!string.IsNullOrEmpty(responseContent))
        //                    {
        //                        Console.WriteLine($"Сообщение сервера: {responseContent}");
        //                    }
        //                    return responseContent;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Ошибка: {ex.Message}");
        //        return string.Empty;
        //    }
        //}
    }
}
