using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

public partial class Images : System.Web.UI.Page
{
    List<string> images = new List<string>();
    List<string> tags = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Get a list of all the tags the user wants the image to have
        if (!Page.IsPostBack)
        {
        int q = 0;
        while (q < Request.QueryString.Count)
        {
            Tags.Text += "<a style='color:#00AAFF;' href='Images.aspx?Catagory=" + Request.QueryString[q] + "'>" + Request.QueryString[q] + "</a>";
            tags.Add(Request.QueryString[q]);
            q++;
        }
        //
            //Category = Request.QueryString[0];
            Name.InnerText = Request.QueryString[0];
            BindData(Datalist,tags);
        }

        //try
        //{
        //    Category = Request.QueryString[Category];
        //}
        //catch
        //{
        //    throw new Exception("QueryString cannot be null");
        //}
        //try
        //{
        //    Tag = Request.QueryString[1];
        //}
        //catch
        //{
        //}
        //if (string.IsNullOrEmpty(Category))
        //{
        //    Category = "Featured";
        //}
        //BindData(Datalist,"~/Images/" + Category);
        //Name.InnerText = Category + " " +Tag;
    }
    public void BindData(DataList Data, List<string> Tags)
    {
        foreach (string tag in Tags)
        {
            StreamReader reader = new StreamReader(MapPath("~/Images/Catagories/" + tag + ".txt"));
            while (!reader.EndOfStream)
            {
                images.Add(reader.ReadLine());
            }
            reader.Close();
            reader.Dispose();
        }
        var groups = images.GroupBy(v => v);
        List<string> result = new List<string>();
        foreach (var group in groups)
        {
            if (group.Count() == Request.QueryString.Count)
            {
                result.Add(group.Key);
            }
        }
        DirectoryInfo directory = new DirectoryInfo(MapPath("~/Images/All/"));
        FileInfo[] fileinfo = directory.GetFiles();
        ArrayList list = new ArrayList();
        foreach (var item in result)
        {
            //if (fileinfo.Contains(new FileInfo(MapPath(item)))
            //{
            //    list.Add(FileInfo.)
            //}
            list.Add(new FileInfo(MapPath(item)));
        }
        Data.DataSource = list;
        Data.DataBind();
        //DirectoryInfo directory = new DirectoryInfo(MapPath(path));
        //FileInfo[] fileinfo = directory.GetFiles();
        //ArrayList list = new ArrayList();
        //foreach (FileInfo file in fileinfo)
        //{
        //    list.Add(file);
        //}
        //    ArrayList List = new ArrayList();
        //    Random r = new Random();
        //    List<int> taken = new List<int>();
        //    while (index < 5 )
        //    {
        //        int number = r.Next(list.Count);
        //        while (!taken.Contains(number))
        //        {
        //            index++;
        //            List.Add(list[number]);
        //            taken.Add(number);
        //        }
        //    }
        //    index = 0;
        //    taken.Clear();
        //    Data.DataSource = List;
        //    Data.DataBind();




    }
    public string Remove(string s)
    {
        string result = "";
        int offset = s.IndexOf(char.Parse("/"));
        offset = s.IndexOf(char.Parse("/"), offset + 1);
        int i = s.IndexOf(char.Parse("/"), offset + 1);
        if (i > 0)
        {
            result = s.Substring(i + 1);
        }
        result = result.Substring(0, result.Count() - 4);
        return result;
    }
    protected void Image_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Display.aspx?Image=" + Remove((sender as ImageButton).ImageUrl));
    }
}