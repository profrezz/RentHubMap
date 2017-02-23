using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace renthubmap.Controllers
{
    public class RenthubController : Controller
    {
        // GET: Renthub
        public ActionResult Index()
        {
            return View();
        }
        private void testcRentHub()
        {
            string filePath = "http://www.renthub.in.th/อพาร์ทเม้นท์-ห้องพัก-หอพัก/ซอยแบริ่ง-สุขุมวิท-107/";
            string data = getHTMLdata(filePath);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;
            htmlDoc.LoadHtml(data);
            if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Count() > 0)
            {
                Console.WriteLine("something error");
            }
            else
            {
                if (htmlDoc.DocumentNode != null)
                {
                    HtmlAgilityPack.HtmlNodeCollection bodyNode = htmlDoc.DocumentNode.SelectNodes("//div[@class='show_content']//ul//li");

                    if (bodyNode != null)
                    {
                        for (int i = 0; i < bodyNode.Count; i++)
                        {
                            var listnode = bodyNode[i];
                            var li = listnode.Attributes["id"].Value;
                            var image = listnode.SelectSingleNode(".//img");
                            var addr = listnode.SelectSingleNode(".//span[@class='addr']");
                            var src = image != null ? image.Attributes["src"].Value : string.Empty;
                            var sublink = listnode.SelectSingleNode(".//span[@class='name']//a").Attributes["href"].Value;
                            var address = addr.InnerText;
                            Console.WriteLine("Scr Image : " + li + " addr : " + address + " image : " + src);

                            // process sub link
                            string filePath_sub = "http://www.renthub.in.th/" + sublink;
                            string data_sub = getHTMLdata(filePath_sub);
                            HtmlAgilityPack.HtmlDocument htmlDoc_sub = new HtmlAgilityPack.HtmlDocument();
                            htmlDoc_sub.OptionFixNestedTags = true;
                            htmlDoc_sub.LoadHtml(data_sub);
                            string searchText = "var loc = ";
                            //string endText =  "var condo_project_id ="; // var apartment_id
                            string endText = "var apartment_id ="; // var apartment_id
                            int start = data_sub.IndexOf(searchText) + searchText.Length;
                            int end = data_sub.IndexOf(endText);
                            var location_hash = data_sub.Substring(start + 1, end - start).Split(';')[0].Replace("\"", "");
                            if (htmlDoc_sub.DocumentNode != null)
                            {
                                var proce_info = htmlDoc_sub.DocumentNode.SelectSingleNode("//div[@id='main_info']").InnerHtml;
                                var main_box = htmlDoc_sub.DocumentNode.SelectSingleNode("//div[@id='main_box']");
                                var image_box = main_box.InnerHtml;
                                var main_infos = main_box.NextSibling.NextSibling.InnerHtml;
                                var price_infos = main_box.NextSibling.NextSibling.NextSibling.NextSibling.InnerHtml;

                                //var main_infos = htmlDoc_sub.DocumentNode.SelectNodes("//div[contains(@class,'condo_listing_content')]");
                                //foreach (var main_info in main_infos)
                                //{
                                //   // var main_infos = main_info.DocumentNode.SelectNodes("//div[@class='condo_listing_box']");
                                //}

                            }
                        }
                    }
                }
            }

        }

        private string getHTMLdata(string filePath)
        {
            //Uri url = new Uri(filePath);
            string data = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(filePath);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, System.Text.Encoding.GetEncoding(response.CharacterSet));
                }

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            return data;
        }
    }
}