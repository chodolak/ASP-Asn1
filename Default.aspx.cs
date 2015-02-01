using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["currentID"] == null)
        {
            Session["currentID"] = 0;
        }

        if (Session["fileSize"] == null)
        {
            Session["fileSize"] = 0;
        }
    }
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        Session["fileSize"] = 0;
        Session["currentID"] = 0;
        Display_Text(0);

        // Disable both Prev and First
        First.CssClass = "btn disabled";
        First.Enabled = false;
        Prev.CssClass = "btn disabled";
        Prev.Enabled = false;

        // Re-enable Next and Last buttons
        Next.CssClass = "btn";
        Next.Enabled = true;
        Last.CssClass = "btn";
        Last.Enabled = true;
    }

    private String Read_File(String file_name)
    {
        String text = "";
        var dataFile = Server.MapPath("~/Files/" + file_name);
        Array userData = File.ReadAllLines(dataFile);
        foreach (string dataLine in userData)
        {

            text += dataLine;
            text += "<br/>";
        }
        return text;
    }

    private String[] Get_Files()
    {
        String[] filePaths = Directory.GetFiles(Server.MapPath("~/Files/"));
        String[] fileNames;
        fileNames = new String[filePaths.Length];

        for (int i = 0; i < filePaths.Length; i++)
        {
            fileNames[i] = filePaths[i].Substring(filePaths[i].LastIndexOf(("\\")) + 1);
        }

        return fileNames;
    }

    private List<String> Search_Files()
    {
        String[] fileNames = Get_Files();
        List<String> filesList = new List<String>();

        for (int i = 0; i < fileNames.Length; i++)
        {
            int picked = 0;
            var dataFile = Server.MapPath("~/Files/" + fileNames[i]);
            Array userData = File.ReadAllLines(dataFile);
            CompareInfo myComp = CultureInfo.InvariantCulture.CompareInfo;

            foreach (string dataLine in userData)
            {
                foreach (string dataItem in dataLine.Split(' '))
                {
					foreach (string searchItems in SearchBox.Text.Split(' '))
					{
						if (Ignore_Words(searchItems))
						{
							if ((myComp.Compare(dataItem, searchItems, CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols)) == 0)
							{
								filesList.Add(fileNames[i]);
								picked = 1;
							}

							if (picked == 1)
							{
								break;
							}
						}
					}

					if (picked == 1)
					{
						break;
					}
                    
                }
                if (picked == 1)
                {
                    break;
                }
            }
        }

        return filesList;
    }
    private List<String> filesList = new List<String>();

    private void Display_Text(int id)
    {

        filesList = Search_Files();
        int s = List_Size();
        if (s == 0)
        {
            Text.Text = "No files have the search items.";
            Title.Text = "";
            SearchCount.Text = "Result 0 of 0";
        }
        else
        {
            String t = Read_File(filesList[id]);
            String i = "Result " + (id + 1).ToString() + " of " + s.ToString();
            Text.Text = t;
            Title.Text = filesList[id];
            SearchCount.Text = i;
        }
    }

    private int List_Size()
    {
        int i = 0;
        foreach (String t in filesList)
        {
            i++;
        }
        Session["fileSize"] = i;
        return i;
    }

    private bool Ignore_Words(String s)
    {
        switch (s)
        {
            case "and": return false;
            case "the": return false;
            case "so": return false;
            case "in": return false;
            case "that": return false;
            case "by": return false;
            case "was": return false;
            case "is": return false;
            case "with": return false;
            case "to": return false;
            case "has": return false;
            case "of": return false;
            case "a": return false;
            default: return true;
        }
    }


    protected void First_Click(object sender, EventArgs e)
    {
        if ((int)Session["currentID"] != 0)
        {
            Session["currentID"] = 0;
            Display_Text((int)Session["currentID"]);

            // Re-enable Next and Last buttons
            Next.CssClass = "btn";
            Next.Enabled = true;
            Last.CssClass = "btn";
            Last.Enabled = true;

            // Disable both Prev and First
            First.CssClass = "btn disabled";
            First.Enabled = false;
            Prev.CssClass = "btn disabled";
            Prev.Enabled = false;
        }
    }

    protected void Prev_Click(object sender, EventArgs e)
    {
        if ((int) Session["currentID"] != 0)
        {
            if ((int)Session["currentID"] == 1)
            {
                // Disable both Prev and First
                First.CssClass = "btn disabled";
                First.Enabled = false;
                Prev.CssClass = "btn disabled";
                Prev.Enabled = false;
            }

            Session["currentID"] = (int) Session["currentID"] - 1;
            Display_Text((int)Session["currentID"]);

            // Re-enable Next and Last buttons
            Next.CssClass = "btn";
            Next.Enabled = true;
            Last.CssClass = "btn";
            Last.Enabled = true;
        }
    }

    protected void Next_Click(object sender, EventArgs e)
    {
        if ((int) Session["currentID"] != (int) Session["fileSize"] - 1)
        {
            Session["currentID"] = (int) Session["currentID"] + 1;
            Display_Text((int) Session["currentID"]);

            // Re-enable Previous and First buttons
            First.CssClass = "btn";
            First.Enabled = true;
            Prev.CssClass = "btn";
            Prev.Enabled = true;

            if ((int)Session["currentID"] == (int)Session["fileSize"] - 1)
            {
                // Disable both Next and Last
                Next.CssClass = "btn disabled";
                Next.Enabled = false;
                Last.CssClass = "btn disabled";
                Last.Enabled = false;
            }
        }
    }

    protected void Last_Click(object sender, EventArgs e)
    {
        if ((int)Session["currentID"] != (int)Session["fileSize"] - 1)
        {
            Session["currentID"] = (int)Session["fileSize"] - 1;
            Display_Text((int)Session["currentID"]);

            // Re-enable Previous and First buttons
            First.CssClass = "btn";
            First.Enabled = true;
            Prev.CssClass = "btn";
            Prev.Enabled = true;

            // Disable both Next and Last
            Next.CssClass = "btn disabled";
            Next.Enabled = false;
            Last.CssClass = "btn disabled";
            Last.Enabled = false;
        }
    }

    protected void printButton_Click(object sender, EventArgs e)
    {

    }

    protected void Download_Click(object sender, EventArgs e)
    {
        List<String> files = new List<String>();
        files = Search_Files();
        if ((int)Session["fileSize"] != 0)
        {
            string filename = files[(int)Session["currentID"]];
            string filepath = "~/Files/" + filename;
            Download_File(filename, filepath);
        }
        
    }

    public static void Download_File(string sFileName, string sFilePath)
    {
        HttpContext.Current.Response.ContentType = "APPLICATION/OCTET-STREAM";
        String Header = "Attachment; Filename=" + sFileName;
        HttpContext.Current.Response.AppendHeader("Content-Disposition", Header);
        System.IO.FileInfo Dfile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath(sFilePath));
        HttpContext.Current.Response.WriteFile(Dfile.FullName);
        HttpContext.Current.Response.End();
    }
}