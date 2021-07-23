﻿using Deliver.Models.DataInfo;
using Newtonsoft.Json;
using PULI.Models.DataInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Deliver.Services
{
    class WebService
    {
        public static string host = "http://59.120.147.32:8080";

        public async Task<LoginInfo> Login(String acc, String pwd, String identity)
        {
            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new StringContent(acc), "acc_user");
            formData.Add(new StringContent(pwd), "acc_password");
            formData.Add(new StringContent(identity), "identity");

            HttpClient _client = new HttpClient();
            var uri = new Uri(string.Format(host + "/lt_care/api/account/login"));

            var response = await _client.PostAsync(uri, formData);
            Console.WriteLine("res~~ " + response.ToString());
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine("content11111" + content);
            if (response.IsSuccessStatusCode)
            {
                
                var list = JsonConvert.DeserializeObject<LoginInfo>(content);
                return list;

            }
            return null;
            
        }
        public async Task<TotalList> Get_Daily_Shipment(string token)
        {
            Console.WriteLine("FHFHFH " + token);
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new StringContent("1"), "type");
            //_client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            var uri = new Uri(string.Format(host + "/lt_care/api/dp/get_daily_shipment"));
            //Console.WriteLine("heeeeeeeder : " + _client.DefaultRequestHeaders);
            var response = await _client.PostAsync(uri, formData);
            //Console.WriteLine("SSS~~ " + response.ToString());
            var content = await response.Content.ReadAsStringAsync();
            //Console.WriteLine("QQQ~~ " + content.ToString());
            if (response.IsSuccessStatusCode)
            {
                
                var list = JsonConvert.DeserializeObject<TotalList>(content);
                Console.WriteLine("GDSEUCESS");
                //Console.WriteLine(list.daily_shipments);
                return list;
            }
            return null;
        }

        public async Task<TotalList> Get_Daily_Shipment_night(string token)
        {
            Console.WriteLine("FHFHFH " + token);
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new StringContent("2"), "type");
            //_client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            var uri = new Uri(string.Format(host + "/lt_care/api/dp/get_daily_shipment"));
            //Console.WriteLine("heeeeeeeder : " + _client.DefaultRequestHeaders);
            var response = await _client.PostAsync(uri, formData);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<TotalList>(content);
                Console.WriteLine("GDSEUCESS");
                //Console.WriteLine(list.daily_shipments);
                return list;
            }
            return null;
        }

        public async Task<stopname> Get_Stop(string token)
        {
            Console.WriteLine("FHFHFH " + token);
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new StringContent("1"), "type");
            //_client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            var uri = new Uri(string.Format(host + "/lt_care/api/dp/get_daily_shipment"));
            //Console.WriteLine("heeeeeeeder : " + _client.DefaultRequestHeaders);
            var response = await _client.PostAsync(uri, formData);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<stopname>(content);
                Console.WriteLine("GDSEUCESS");
                //Console.WriteLine(list.daily_shipments);
                return list;
            }
            return null;
        }
        public async Task<restorename> Get_Restore(string token)
        {
            Console.WriteLine("FHFHFH " + token);
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new StringContent("1"), "type");
            //_client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            var uri = new Uri(string.Format(host + "/lt_care/api/dp/get_daily_shipment"));
            //Console.WriteLine("heeeeeeeder : " + _client.DefaultRequestHeaders);
            var response = await _client.PostAsync(uri, formData);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<restorename>(content);
                Console.WriteLine("GDSEUCESS");
                //Console.WriteLine(list.daily_shipments);
                return list;
            }
            return null;
        }
        public async Task<List<deliver>> Get_Daily_Shipment2(string token)
        {
            
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new StringContent("1"), "type");
            //_client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            var uri = new Uri(string.Format(host + "/lt_care/api/dp/get_daily_shipment"));
            //Console.WriteLine("heeeeeeeder : " + _client.DefaultRequestHeaders);
            var response = await _client.PostAsync(uri, formData);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("content~~~ " + content.ToString());
                Console.WriteLine("response~~~ " + response.ToString());
                var list = JsonConvert.DeserializeObject<List<deliver>>(content);
                Console.WriteLine("SEUCESS");
                //Console.WriteLine(list.daily_shipments);
                return list;
            }
            else
            {
                Console.WriteLine("Error ALL : " + response.ToString());
                return null;
            }
            return null;
        }
        public async Task<IEnumerable<ClientInfo>> Get_Client(string token)
        {

            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            MultipartFormDataContent formData = new MultipartFormDataContent();
            //formData.Add(new StringContent("1"), "type");
            //_client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            var uri = new Uri(string.Format(host + "/lt_care/api/dp/get_client"));
            //Console.WriteLine("heeeeeeeder : " + _client.DefaultRequestHeaders);
            var response = await _client.PostAsync(uri, null);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<IEnumerable<ClientInfo>>(content);
                Console.WriteLine("GCSUCESS");
                return list;
            }
            return null;
        }
        public async Task<List<ClientInfo>> Get_Client2(string token)
        {

            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            MultipartFormDataContent formData = new MultipartFormDataContent();
            //formData.Add(new StringContent("1"), "type");
            //_client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            var uri = new Uri(string.Format(host + "/lt_care/api/dp/get_client"));
            //Console.WriteLine("heeeeeeeder : " + _client.DefaultRequestHeaders);
            var response = await _client.PostAsync(uri, null);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<ClientInfo>>(content);
                Console.WriteLine("GC22SUCESS");
                return list;
            }
            return null;
        }
        public async Task<List<AllClientInfo>> Get_All_Client(string token)
        {

            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            MultipartFormDataContent formData = new MultipartFormDataContent();
            //formData.Add(new StringContent("1"), "type");
            //_client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            var uri = new Uri(string.Format(host + "/lt_care/api/sw/get_all_clients"));
            //Console.WriteLine("heeeeeeeder : " + _client.DefaultRequestHeaders);
            var response = await _client.PostAsync(uri, null);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("GETALL~~~~");
                var content = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<AllClientInfo>>(content);
                return list;
            }
            else
            {
                Console.WriteLine("Error GET ALL : " + response.ToString());
                return null;
            }
            
        }

        public async Task<List<AllClientInfo2>> Get_All_Client2(string token)
        {

            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            MultipartFormDataContent formData = new MultipartFormDataContent();
            //formData.Add(new StringContent("1"), "type");
            //_client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
            var uri = new Uri(string.Format(host + "/lt_care/api/sw/get_all_clients"));
            //Console.WriteLine("heeeeeeeder : " + _client.DefaultRequestHeaders);
            var response = await _client.PostAsync(uri, null);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("GETALL~~~~");
                var content = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<AllClientInfo2>>(content);
                return list;
            }
            else
            {
                Console.WriteLine("Error GET ALL : " + response.ToString());
                return null;
            }

        }
        public async Task<bool> Save_Punch_In(string token, string ct_s_num, string sec_s_num, string mlo_s_num, double lat, double lot)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Token " + token);
                Console.WriteLine("TOKEN>>>> " + token);
                MultipartFormDataContent formData = new MultipartFormDataContent();
                //formData.Add(tempData);
                formData.Add(new StringContent(ct_s_num), "ct_s_num");
                Console.WriteLine("NAME>>>> " + ct_s_num);
                formData.Add(new StringContent(sec_s_num), "sec_s_num");
                Console.WriteLine("SEC_S_NUM>>>> " + sec_s_num);
                formData.Add(new StringContent(mlo_s_num), "mlo_s_num");
                Console.WriteLine("MLO>>>> " + mlo_s_num);
                
                formData.Add(new StringContent("1"), "phl01");
                formData.Add(new StringContent("1"), "phl02");
                formData.Add(new StringContent(lot.ToString()), "phl03");
                Console.WriteLine("LOT>>>> " + lot.ToString());
                formData.Add(new StringContent(lat.ToString()), "phl04");
                Console.WriteLine("LAT>>>> " + lat.ToString());
                formData.Add(new StringContent("1"), "phl05");
                formData.Add(new StringContent("1"), "phl99");
                Console.WriteLine("NAME>>>> " + ct_s_num);
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(host + "/lt_care/api/dp/save_punch"),
                    Method = HttpMethod.Post,
                    Content = formData
                };
                request.Headers.Add("Connection", "closed");
                //request.Headers.Add("Accept-Encoding", "identity"); //I added it.

                var response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("content" + content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(ct_s_num + "INN");
                    
                    Console.WriteLine("punchincontent" + content);
                    if (content == "ok")
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("punchincontentfail" + content);
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error Message111 : " + response.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message222 : " + ex.ToString());
                return false;
            }
            
        }
        public async Task<bool> Save_Punch_Out(string token, string ct_s_num, string sec_s_num, string mlo_s_num, double lat, double lot)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);

                MultipartFormDataContent formData = new MultipartFormDataContent();
                //formData.Add(tempData);
                formData.Add(new StringContent(ct_s_num), "ct_s_num");
                formData.Add(new StringContent(sec_s_num), "sec_s_num");
                formData.Add(new StringContent(mlo_s_num), "mlo_s_num");
               
                formData.Add(new StringContent("0"), "phl01");
                formData.Add(new StringContent("2"), "phl02");
                formData.Add(new StringContent(lot.ToString()), "phl03");
                formData.Add(new StringContent(lat.ToString()), "phl04");
                formData.Add(new StringContent("1"), "phl05");
                formData.Add(new StringContent("1"), "phl99");

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(host + "/lt_care/api/dp/save_punch"),
                    Method = HttpMethod.Post,
                    Content = formData
                };
                request.Headers.Add("Connection", "closed");
                //request.Headers.Add("Accept-Encoding", "identity");
                var response = await client.SendAsync(request);
                //Console.WriteLine("RES" + response);
                var content = await response.Content.ReadAsStringAsync();
                //Console.WriteLine("content" + content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(ct_s_num + "OUT");
                    
                    if (content == "ok")
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error Message : " + response.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message : " + ex.ToString());
                return false;
            }

        }

        public async Task<bool> Beacon_Punch(string token, string bnl01_uuid, string bnl02)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);

                MultipartFormDataContent formData = new MultipartFormDataContent();
                //formData.Add(tempData);
                formData.Add(new StringContent(bnl01_uuid), "bnl01_uuid");
                formData.Add(new StringContent(bnl02), "bnl02");
                

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(host + "/lt_care/api/dp/save_beacon"),
                    Method = HttpMethod.Post,
                    Content = formData
                };
                request.Headers.Add("Connection", "closed");
                //request.Headers.Add("Accept-Encoding", "identity");
                var response = await client.SendAsync(request);
                //Console.WriteLine("RES" + response);
                var content = await response.Content.ReadAsStringAsync();
                //Console.WriteLine("content" + content);
                if (response.IsSuccessStatusCode)
                {

                    if (content == "ok")
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error Message : " + response.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message : " + ex.ToString());
                return false;
            }
        }

        public async Task<List<questionnaire>> Get_Questionaire(string token)
        {

            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);

            var uri = new Uri(string.Format(host + "/lt_care/api/dp/get_work_q"));
            var response = await _client.PostAsync(uri, null);
            //var content2 = await response.Content.ReadAsStringAsync();
            Console.WriteLine("RES~~ " + response.ToString());
           
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("con~~~ " + content.ToString());
                var list = JsonConvert.DeserializeObject<List<questionnaire>>(content);
                return list;
                Console.WriteLine("GETQOOO");
            }
            else
            {
                Console.WriteLine("ERRORGET");
            }
            return null;
        }

        
        public async Task<List<qb>> Get_Qb(string token)
        {

            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);

            var uri = new Uri(string.Format(host + "/lt_care/api/dp/get_work_q"));
            var response = await _client.PostAsync(uri, null);
            //var content2 = await response.Content.ReadAsStringAsync();
            //Console.WriteLine("RES" + response);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<qb>>(content);
                return list;
                //Console.WriteLine("GETQOOO");
            }
            else
            {
                Console.WriteLine("ERRORGETQB");
            }
            return null;
        }
        public async Task<bool> Save_Questionaire(string token, work_data resault)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(resault);

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
                HttpContent content = new StringContent(jsonString);
                Console.WriteLine("content~" + content);
                //string url = "http://59.120.147.32:8080/lt_care/api/dp/save_work_q";
                var url = new Uri(string.Format(host + "/lt_care/api/dp/save_work_q"));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
               
                var response = await client.PostAsync(url, content);
                Console.WriteLine("RESSS" + response.ToString());
                Console.WriteLine("WWEEE " + content.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    if (msg == "ok")
                    {
                        Console.WriteLine("QOO");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Error Save 2: " + msg);
                        return false;
                        
                    }
                }
                else
                {
                    Console.WriteLine("Error Save1 : " + response.ToString());
                    Console.WriteLine("QAQ~~~ " + content.ToString());
                    return false;
                    
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Save : " + ex.ToString());
                return false;
            }
                
            
        }

        public async Task<bool> Post_work(string token, string note, StreamContent img_sc)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);
                MultipartFormDataContent formData = new MultipartFormDataContent();
                //img_sc.Headers.Add("Content-Type", "image/jpeg");

                if (!string.IsNullOrEmpty(note))
                    formData.Add(new StringContent(note), "WorkLogNote");
                //WorkLogPicture
                formData.Add(img_sc, "WorkLogPicture", "WorkLogPicture");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(host + "/lt_care/api/account/save_worklog"),
                    Method = HttpMethod.Post,
                    Content = formData
                };
                request.Headers.Add("Connection", "closed");

                var response = await client.SendAsync(request);
                Console.WriteLine("WHY ~  " + response.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (content == "ok")
                    {
                        return true;
                        Console.WriteLine("ok_post_work~~ ");
                    }
                    else
                    {
                        return false;
                        Console.WriteLine("================================ : " + content);
                    }
                }
                else
                {
                    return false;
                    Console.WriteLine("WHY2~ ");
                    Console.WriteLine("WHY ~2" + response.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error post_work : " + ex.ToString());
                return false;
            }


        }

        public async Task<bool> Save_New_Client_Info(string token, string ct01, string ct02, string ct03, string ct04, string ct05, string ct06_homephone, string ct06_telephone,double ct16_actual, double ct17_actual, StreamContent img_sc)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Token " + token);

                MultipartFormDataContent formData = new MultipartFormDataContent();
                //formData.Add(tempData);
                formData.Add(new StringContent(ct01), "ct01");
                formData.Add(new StringContent(ct02), "ct02");
                formData.Add(new StringContent(ct03), "ct03");
               
                formData.Add(new StringContent(ct04), "ct04");
                formData.Add(new StringContent(ct05), "ct05");
                formData.Add(new StringContent(ct06_homephone), "ct06_homephone");
                formData.Add(new StringContent(ct06_telephone), "ct06_telephone");
                formData.Add(new StringContent(ct16_actual.ToString()), "ct16_actual");
                formData.Add(new StringContent(ct17_actual.ToString()), "ct17_actual");
                if(img_sc != null)
                {
                    formData.Add(img_sc, "ct94", "ct94");
                }
                

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(host + "/lt_care/api/sw/save_clients"),
                    Method = HttpMethod.Post,
                    Content = formData
                };
                request.Headers.Add("Connection", "closed");
                //request.Headers.Add("Accept-Encoding", "identity"); //I added it.

                var response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("content" + content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(ct02 + "SAVENEW~~~~");

                    //Console.WriteLine("punchincontent" + content);
                    if (content == "ok")
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error Message111 : " + response.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message222 : " + ex.ToString());
                return false;
            }

        }

        public async Task<bool> Save_ReNew_Client_Info(string token,string s_num, string ct01, string ct02, string ct03, string ct04, string ct05, string ct06_homephone, string ct06_telephone)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Token " + token);

                MultipartFormDataContent formData = new MultipartFormDataContent();
                //formData.Add(tempData);
                formData.Add(new StringContent(s_num), "s_num");
                formData.Add(new StringContent(ct01), "ct01");
                formData.Add(new StringContent(ct02), "ct02");
                formData.Add(new StringContent(ct03), "ct03");
               
                formData.Add(new StringContent(ct04), "ct04");
                formData.Add(new StringContent(ct05), "ct05");
                formData.Add(new StringContent(ct06_homephone), "ct06_homephone");
                formData.Add(new StringContent(ct06_telephone), "ct06_telephone");


                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(host + "/lt_care/api/sw/upd_clients"),
                    Method = HttpMethod.Post,
                    Content = formData
                };
                request.Headers.Add("Connection", "closed");
                //request.Headers.Add("Accept-Encoding", "identity"); //I added it.

                var response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("content" + content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(ct02 + "SAVERENEW~~~~");

                    //Console.WriteLine("punchincontent" + content);
                    if (content == "ok")
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error Message111 : " + response.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message222 : " + ex.ToString());
                return false;
            }

        }

        public async void post_gps(string token, string lat, string lot)
        {
            try
            {
                Console.WriteLine("postGPS~~~");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("AUTHORIZATION", "Token " + token);

                MultipartFormDataContent formData = new MultipartFormDataContent();
                //formData.Add(tempData);
                formData.Add(new StringContent(lat), "gsl01");//打卡經度
                formData.Add(new StringContent(lot), "gsl02");//打卡緯度
                Console.WriteLine("yyyyyyyyyyyyyyy經度 : " + lat);
                Console.WriteLine("xxxxxxxxxxxxxxxx緯度 : " + lot);
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(host + "/lt_care/api/account/save_gps"),
                    Method = HttpMethod.Post,
                    Content = formData
                };
                request.Headers.Add("Connection", "closed");

                await client.SendAsync(request);//no response
                //var response = await client.SendAsync(request);
                //var content = await response.Content.ReadAsStringAsync();
                ////Console.WriteLine("content" + content);
                //if (response.IsSuccessStatusCode)
                //{
                //    //Console.WriteLine("uploadGPSsuccess~~~");
                //}
                //else
                //{
                //    //Console.WriteLine("uploadGPSfail~~~");
                //}

            }
            catch (Exception ex)
            {
                ;
            }
        }

        //public async Task<bool> Save_New_Client_Info2(string token, AllClientInfo insertList)
        //{

        //    try
        //    {
        //        var str = JsonConvert.SerializeObject(insertList);
        //        //Uri uri = new Uri(string.Format(host + "/reserve/insert_res"));
        //        Uri uri = new Uri("http://59.120.147.32:8080/lt_care/api/sw/save_clients"),
        //        HttpContent post_content = new StringContent(str);

        //        post_content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        HttpClient _client = new HttpClient();
        //        var response = await _client.PostAsync(uri, post_content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var content = await response.Content.ReadAsStringAsync();
        //            var list = JsonConvert.DeserializeObject<string>(content);
        //            return list;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Error Message : " + response.ToString());
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error Message : " + ex.ToString());
        //        return null;
        //    }

        //}
    }
}