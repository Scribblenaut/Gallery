using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Xml;

public partial class _Default : System.Web.UI.Page
{
    //int index;
    List<KeyValuePair<object, int>> votes = new List<KeyValuePair<object, int>>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //SetUp();
            BindDataList(Featured, "Featured");
            BindDataList(Popular, "Popular");
            BindDataList(New, "New");
        }

    }
    public void SetUp()
    {
        //DirectoryInfo directory = new DirectoryInfo(MapPath("~/Images/All/"));
        //FileInfo[] All = directory.GetFiles();

        //DirectoryInfo directory1 = new DirectoryInfo(MapPath("~/Info/"));
        //FileInfo[] Info = directory1.GetFiles();

        //List<KeyValuePair<string, string>> Tags = new List<KeyValuePair<string, string>>();

        //foreach (FileInfo info in Info)
        //{
        //    //StreamReader reader = new StreamReader(info.FullName);
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(info.FullName);
        //        Tags.Add( new KeyValuePair<string,string>(info.Name,reader.ReadLine()));

        //    reader.Close();
        //    reader.Dispose();
        //}
        //foreach (KeyValuePair<string,string> tag in Tags)
        //{
        //    List<string> contents = new List<string>();
        //    StreamReader reader = new StreamReader("~/Images/All/" + tag.Value.Replace(".png", ".txt"));
        //    while (!reader.EndOfStream)
        //    {
        //        contents.Add(reader.ReadLine());
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    StreamWriter writer = new StreamWriter("~/Images/All/" + tag.Value.Replace(".png", ".txt"));
        //    contents[3] = "Tags:" + tag.Key;
            
            
        //}

        
    }
    public void BindDataList(DataList Data, string path)
    {
        //DataClassesDataContext db = new DataClassesDataContext();
        //var paths = from i in db.Images
        //            select i.Path;

        //StreamReader reader = new StreamReader(MapPath("~/Images/Catagories/" + path + ".txt"));
        XmlDocument doc = new XmlDocument();
        doc.Load(MapPath("~/Images/Catagories/" + path + ".xml"));
        List<string> paths = new List<string>();
        int n = 0;
        foreach(XmlNode node in doc.DocumentElement.ChildNodes)
        {
            n++;
            paths.Add(node.InnerText);
            //if (n > 10)
            //{
            //    throw new Exception();
            //}
        }
        //reader.Close();
        //reader.Dispose();
        DirectoryInfo directory = new DirectoryInfo(MapPath("~/Images/All/"));
        FileInfo[] fileinfo = directory.GetFiles();
        ArrayList list = new ArrayList();
        foreach (FileInfo file in fileinfo)
        {
            //foreach (string p in paths)
            //{
            //    if (p != file.FullName)
            //    {
            //        db.StoredProcedure2(file.Name, file.FullName, 0, DateTime.Now);
            //    }
            //}
            //try
            //{
            //    var v = from i in db.Images
            //            where i.Path == file.FullName
            //            select i.VoteScore.Value;
            //    int vote = v.First();
            //    votes.Add(new KeyValuePair<object, int>(file, vote));
            //}
            //catch
            //{
            //}
            //if (!File.Exists(MapPath("~/Info/" + file.Name + ".txt")))
            //{
            //    StreamWriter writer = new StreamWriter(MapPath("~/Info/" + file.Name + ".txt"));
            //    writer.WriteLine("Author:Marissa Hudson");
            //    writer.WriteLine("Votes:0");
            //    writer.WriteLine("Tags:");
            //    writer.WriteLine("DownloadLinks:");
            //    writer.Close();
            //    writer.Dispose();

            //}
            if(paths.Contains(file.Name))
            {
                list.Add(file);
            }
            //votes.Sort(Compare);
            //foreach (var v in votes)
            //{
            //    list.Add(v.Key);
            //}

        }
        ArrayList List = new ArrayList();
        Random r = new Random();
        //List<int> taken = new List<int>();
        //while (index < 5)
        //{
        //    int number = r.Next(list.Count);
        //    while (!taken.Contains(number))
        //    {
        //        index++;
        //        List.Add(list[number]);
        //        taken.Add(number);
        //    }
        //    //List.Add(list[number]);
            //int number = r.Next(list.Count);
            List.Add(list[0]);
            List.Add(list[1]);
            List.Add(list[2]);
            List.Add(list[3]);
            List.Add(list[4]);

        //}
        //index = 0;
        //taken.Clear();
        Data.DataSource = List;
        Data.DataBind();
        //throw new Exception("Naw");



    }
    static int Compare(KeyValuePair<object, int> a, KeyValuePair<object, int> b)
    {
        return b.Value.CompareTo(b.Value);
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
        result = result.Substring(0,result.Count() - 4);
        return result;
    }
    protected void Featured1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Display.aspx?Image=" + Remove((sender as ImageButton).ImageUrl));
    }
    protected void Popular1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Display.aspx?Image=" + Remove((sender as ImageButton).ImageUrl));
    }
    protected void New1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Display.aspx?Image=" + Remove((sender as ImageButton).ImageUrl));
    }
    protected void up_Click(object sender, ImageClickEventArgs e)
    {
        string image = (sender as ImageButton).AlternateText;
        //int votes = 0;
        List<string> Text = new List<string>();
        //StreamReader reader = new StreamReader(MapPath("~/Info/" + image + ".txt"));
        XmlDocument doc = new XmlDocument();
        doc.Load(MapPath("~/Info/" + image + ".xml"));
        foreach(XmlNode node in doc.DocumentElement.ChildNodes)
        {
            //Text.Add(node.InnerText);
            if (node.Name == "votes")
            {
                node.InnerText = ((int.Parse(node.InnerText)) + 1).ToString();
            }
        }
        doc.Save(MapPath("~/Info/" + image + ".xml"));
        //reader.Close();
        //reader.Dispose();
        //string s = Text[1];
        //string t = s.Remove(0, 6);
        //votes = int.Parse(t);
        //Text[1] = "Votes:" + (votes + 1).ToString();
        //doc.SelectSingleNode("/Votes").InnerText = Text[1];
        ////StreamWriter writer = new StreamWriter(MapPath("~/Info/" + image + ".txt"));
        //foreach (string l in Text)
        //{
            
        //    //writer.WriteLine(l);
        //}
        ////writer.Close();
        ////writer.Dispose();
        
    }
    protected void down_Click(object sender, ImageClickEventArgs e)
    {
        string image = (sender as ImageButton).AlternateText;
        List<string> Text = new List<string>();
        XmlDocument doc = new XmlDocument();
        doc.Load(MapPath("~/Info/" + image + ".xml"));
        foreach (XmlNode node in doc.DocumentElement.ChildNodes)
        {
            if (node.Name == "votes")
            {
                node.InnerText = ((int.Parse(node.InnerText)) - 1).ToString();
            }
        }
        doc.Save(MapPath("~/Info/" + image + ".xml"));
        
    }
    //protected void score_DataBinding(object sender, EventArgs e)
    //{
    //    string image = (sender as Label).ToolTip;
    //    List<string> contents = new List<string>();
    //    StreamReader reader = new StreamReader(MapPath("~/Info/" + image + ".txt"));
    //    while (!reader.EndOfStream)
    //    {
    //        contents.Add(reader.ReadLine());
    //    }
    //    int value = int.Parse(contents[1].Remove(0, 6));
    //    try
    //    {
    //        ((Featured.FindControl((sender as Label).ID)) as Label).Text = value.ToString();

    //    }
    //    catch
    //    {
    //        try
    //        {
    //            ((Popular.FindControl((sender as Label).ID)) as Label).Text = value.ToString();
    //        }
    //        catch
    //        {
    //            try
    //            {
    //                ((New.FindControl((sender as Label).ID)) as Label).Text = value.ToString();
    //            }
    //            catch
    //            {

    //            }
    //        }

    //    }

    //}
}
