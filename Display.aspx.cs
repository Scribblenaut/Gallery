using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Display : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string image = Request.QueryString[0];
        string path = "~/Images/All/" + image + ".png";
        //int vote = 0;
        List<KeyValuePair<string, string>> tags = new List<KeyValuePair<string, string>>();

        DirectoryInfo directory = new DirectoryInfo(MapPath("~/Images/Catagories/"));
        FileInfo[] fileinfo = directory.GetFiles();
        foreach(FileInfo file in fileinfo)
        {
            StreamReader reader = new StreamReader(MapPath("~/Images/Catagories/" + file.Name));
            while (!reader.EndOfStream)
            {
                tags.Add(new KeyValuePair<string,string>(file.Name,reader.ReadLine()));
            }
            //DownloadLinks
            reader.Close();
            reader.Dispose();
        }
            foreach (var tag in tags)
            {
                if (tag.Value.Contains(image))
                {
                    Tags.Text += "<a style='color:#00AAFF;' href='Images.aspx?Catagory=" + tag.Key.Remove(tag.Key.Count() - 4, 4) + "'>" + tag.Key.Remove(tag.Key.Count() - 4, 4) + "</a>" + " ";//#00AAFF
                }
            }

            StreamReader read = new StreamReader(MapPath("~/Info/" + image + ".png.txt"));
            List<string> info = new List<string>();
            while (!read.EndOfStream)
            {
                info.Add(read.ReadLine());
            }
            Author.Text = info[0].Remove(0, 7);
            MainImage.ImageUrl = path;
            Name.InnerText = image;
            Votes.Text = info[1].Remove(0,6);
    }
    protected void MainImage_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect((sender as ImageButton).ImageUrl);
    }
}