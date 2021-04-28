using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace XmlCrud.App_Code
{
    public class SongMethods
    {
        private DataSet ds = new DataSet("playlist");

        

        public DataSet GetAllSongs(string File)
        {
            
            DataTable dtSong = new DataTable("song");

            DataColumn dcId = new DataColumn("id");
            DataColumn dcTitle = new DataColumn("title");
            DataColumn dcArtist = new DataColumn("artist");
            DataColumn dcYear = new DataColumn("year");
            DataColumn dcTime = new DataColumn("time");
            DataColumn dcGenre = new DataColumn("genre");
            DataColumn dcFile = new DataColumn("file");

            dtSong.Columns.Add(dcId);
            dtSong.Columns.Add(dcTitle);
            dtSong.Columns.Add(dcArtist);
            dtSong.Columns.Add(dcYear);
            dtSong.Columns.Add(dcTime);
            dtSong.Columns.Add(dcFile);

            ds.ReadXml(HttpContext.Current.Server.MapPath("~/App_Data/PlayList.xml"));
            return ds;
        }
        public DataRow GetEmtyDataRow()
        {
            DataRow dr = ds.Tables["song"].NewRow();
            return dr;
        }

        public void CreateSong(DataRow dataRow)
        {
            ds.Tables["song"].Rows.Add(dataRow);
            ds.WriteXml(HttpContext.Current.Server.MapPath("~/App_Data/PlayList.xml"));
        }

    }
    
}

