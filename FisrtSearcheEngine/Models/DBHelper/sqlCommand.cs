using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

public class sqlCommand
{
    public static string StringConnection = "Server=localhost; Database=telegram_plus; Integrated Security=True;";

    private static string sSplitedStr = "{0}";

    public sqlCommand()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public static bool CHECK_IF_NOT_EXIST = true;
    public static bool CHECK_IF_EXIST = false;

    public class Apk_Activity
    {
        public static string TABLE_NAME = "Apk_Activity";

        public static string ID = "id";
        public static string UPLOAD_DATE = "upload_date";
        public static string APK_NAME = "apk_name";
        public static string UPDATETIME = "updatetime";
        public static string APK_URI = "apk_uri";

        public static int ID_INDEX = 0;
        public static int UPLOAD_DATE_INDEX = 1;
        public static int APK_NAME_INDEX = 2;
        public static int UPDATETIME_INDEX = 3;
        public static int APK_URI_INDEX = 4;
    }

    public class Contact_Users
    {
        public static string TABLE_NAME = "con_users";

        public static string ID = "id";
        public static string IMEI = "IMEI";
        public static string EXT_DATA = "ext_data";
        public static string NUM_PHONE = "num_phone";
        public static string NAME_PHONE = "name_phone";
        public static string HASH_DATA = "hash_data";

        public static int ID_INDEX = 0;
        public static int IMEI_INDEX = 1;
        public static int EXT_DATA_INDEX = 2;
        public static int NUM_PHONE_INDEX = 3;
        public static int NAME_PHONE_INDEX = 4;
        public static int HASH_DATA_INDEX = 5;
    }

    public class Popup
    {
        public static string TABLE_NAME = "Popup";

        public static string ID = "id";
        public static string MSG = "msg";
        public static string CREATE_DATE = "create_date";
        public static string NOTI_TYPE = "noti_type";

        public static int ID_INDEX = 0;
        public static int MSG_INDEX = 1;
        public static int CREATE_DATE_INDEX = 2;
        public static int NOTI_TYPE_INDEX = 3;
    }

    public class Notifications
    {
        public static string TABLE_NAME = "Notifications";

        public static string ID = "id";
        public static string MSG = "msg";
        public static string CREATE_DATE = "create_date";
        public static string NOTI_TYPE = "noti_type";

        public static int ID_INDEX = 0;
        public static int MSG_INDEX = 1;
        public static int CREATE_DATE_INDEX = 2;
        public static int NOTI_TYPE_INDEX = 3;
    }

    public class Registered_Users
    {
        public static string TABLE_NAME = "registered_users";

        public static string ID = "id";
        public static string NAME = "name";
        public static string DL_DATE = "dl_date";
        public static string REG_DATE = "reg_date";
        public static string USE_DATE = "use_date";
        public static string PHONE_NUM = "phone_num";
        public static string IMEI = "imei";
        public static string TELEGRAM_ID = "telegram_id";
        public static string IUSE_DATE = "iUse_Date";
        

        public static int ID_INDEX = 0;
        public static int NAME_INDEX = 1;
        public static int DL_DATE_INDEX = 2;
        public static int REG_DATE_INDEX = 3;
        public static int USE_DATE_INDEX = 4;
        public static int PHONE_NUM_INDEX = 5;
        public static int IMEI_INDEX = 6;
        public static int TELEGRAM_ID_INDEX = 7;
        public static int IUSE_DATE_INDEX = 8;
    }

    public class tmp_table
    {
        public static string TABLE_NAME = "tmp_table";

        public static string ID = "id";
        public static string LAT = "lat";
        public static string LNG = "lng";
        public static string RESV = "resv";

        public static int ID_INDEX = 0;
        public static int LAT_INDEX = 1;
        public static int LNG_INDEX = 2;
        public static int RESV_INDEX = 3;
    }

    public class Category
    {
        public static string TABLE_NAME = "category";

        public static string ID = "id";
        public static string CAT = "cat";
        public static string IMG = "img";
        public static string UPDATETIME = "updatetime";
        public static string LAYERS = "lays";
        public static string LISTS = "lists";
    }

    public class Profiles
    {
        public static string TABLE_NAME = "profiles";

        public static string ID             = "id";
        public static string WORK_NAME      = "work_name";
        public static string CATEGORY       = "category";
        public static string SUBCATEGORY    = "subcategory";
        public static string PHONES         = "phones";
        public static string DISCOUNTS      = "discounts";
        public static string FACILITIES     = "facilities";
        public static string ABOUT          = "about";
        public static string WEEK           = "week";
        public static string WEEK_COMMENT   = "week_comment";
        public static string GALLERY        = "gallery";
        public static string LOCATION       = "location";
        public static string AVATAR         = "avatar";
        public static string DATE_CREATE    = "date_create";
        public static string DATE_START     = "date_start";
        public static string DATE_END       = "date_end";
        public static string UPDATETIME     = "updatetime";
        public static string VALID          = "valid";
    }

    public class Popups
    {
        public static string TABLE_NAME = "popups";

        public static string ID = "id";
        public static string ID_POINTER = "id_pointer";
        public static string MSG = "msg";
        public static string DATE = "date";
        public static string NUM_CLICK = "num_click";
        public static string NUM_CLEAR = "num_clear";
        public static string NUM_RECEIVE = "num_receive";
    }

    public class Banners
    {
        public static string TABLE_NAME = "banners";

        public static string ID = "id";
        public static string ID_POINTER = "id_pointer";
        public static string BANNER_NAME = "banner_name";
        public static string DATE = "date";
        public static string NUM_CLICK = "num_click";
        public static string NUM_RECEIVE = "num_receive";
        public static string TOP_BOTTOM = "top_bottom";
        public static string UPDATETIME = "updatetime";
    }

    public class Users
    {
        public static string TABLE_NAME = "Users";

        public static string ID = "id";
        public static string NAME_USER = "name_user";
        public static string FAMILY_USER = "family_user";
        public static string IMEI = "imei";
        public static string ACCOUNTS = "accounts";
        public static string USERNAME = "username";
        public static string PASSWORD = "password";
        public static string MOBILE = "mobile";
        public static string EMAIL = "email";
        public static string BIRTHDAY = "birthday";
        public static string REGISTER_DATE = "register_date";
        public static string DOWNLOAD_DATE = "download_date";
        public static string PROFILE_IDS = "profile_ids";
        public static string DISCOUNTS = "discounts";
        public static string VALID = "valid";
    }

    public class COMMENTS
    {
        public static string TABLE_NAME = "comments";

        public static string ID = "id";
        public static string PROFILE_ID = "profile_id";
        public static string USER_ID = "user_id";
        public static string NAME = "name";
        public static string FAMILY = "family";
        public static string COMMENT = "comment";
        public static string DATE = "date";
        public static string UPDATETIME = "updatetime";
    }

    public class ADMINCOMMENTS
    {
        public static string TABLE_NAME = "admincomments";

        public static string ID = "id";
        public static string PROFILE_ID = "profile_id";
        public static string USER_ID = "user_id";
        public static string COMMENT = "comment";
        public static string DATE = "date";
        public static string UPDATETIME = "updatetime";
    }

    public class RSS
    {
        public static string TABLE_NAME = "RSS";

        public static string ID = "id";
        public static string RSS_LINK = "rss_link";
        public static string IMAGE = "img";
        public static string UPDATETIME = "updatetime";
    }

    public class mainCategory
    {
        public static string[] rows = { "پوشاک", "جشن و عروسی", "آرایش و زیبایی", "تندرستی و زیبایی", "لوازم و آرایشی و زیبایی", "لوازم برقی و آرایشی و زیبایی" };

    }

    public static string makeWhereIn(string par1, string val1)
    {
        return " where " + par1 + " in (" + val1 + ")";     //where ID in (5263, 5625, 5628, 5621) 
    }

    public static string makeWhere(string par1, string val1)
    {
        return " where " + par1 + "=N'" + val1 + "'";
    }

    public static string makeWhere(string par1, string val1, string par2, string val2)
    {
        return " where " + par1 + "=N'" + val1 + "' and " + par2 + "=N'" + val2 + "'";
    }

    public static string makeWhere(string par1, string val1, string par2, string val2, string par3, string val3)
    {
        return " where " + par1 + "=N'" + val1 + "' and " + par2 + "=N'" + val2 + "' and " + par3 + "=N'" + val3 + "'";
    }

    public static string makeWhere(string par1, string val1, string par2, string val2, string par3, string val3, string par4, string val4)
    {
        return " where " + par1 + "=N'" + val1 + "' and " + par2 + "=N'" + val2 + "' and " + par3 + "=N'" + val3 + "' and " + par4 + "=N'" + val4 + "'";
    }

    public static string Select(string table, string where)
    {
        return "SELECT * FROM " + table + where;
    }

    public static string Select(string table)
    {
        return "SELECT * FROM " + table + ";";
    }

    public static string makeParam(string par1, string val1)
    {
        return " (" + par1 + ") VALUES (N'" + val1 + "')";
    }

    public static string makeParam(string par1, string val1, string par2, string val2)
    {
        return " (" + par1 + "," + par2 + ") VALUES (N'" + val1 + "', N'" + val2 + "')";
    }

    public static string makeParam(string par1, string val1, string par2, string val2, string par3, string val3)
    {
        return " (" + par1 + "," + par2 + "," + par3 + ") VALUES (N'" + val1 + "', N'" + val2 + "', N'" + val3 + "')";
    }

    public static string makeParam(string par1, string val1, string par2, string val2, string par3, string val3, string par4, string val4)
    {
        return " (" + par1 + "," + par2 + "," + par3 + "," + par4 + ") VALUES (N'" + val1 + "', N'" + val2 + "', N'" + val3 + "', N'" + val4 + "')";
    }

    public static string makeParam(string par1, string val1, string par2, string val2, string par3, string val3, string par4, string val4, string par5, string val5)
    {
        return " (" + par1 + "," + par2 + "," + par3 + "," + par4 + "," + par5 + ") VALUES (N'" + val1 + "', N'" + val2 + "', N'" + val3 + "', N'" + val4 + "', N'" + val5 + "')";
    }

    public static string makeParam(string par1, string val1, string par2, string val2, string par3, string val3, string par4, string val4, string par5, string val5, string par6, string val6, string par7, string val7, string par8, string val8)
    {
        return " (" + par1 + "," + par2 + "," + par3 + "," + par4 + "," + par5 + "," + par6 + "," + par7 + "," + par8 + ") VALUES (N'" + val1 + "', N'" + val2 + "', N'" + val3 + "', N'" + val4 + "', N'" + val5 + "', N'" + val6 + "', N'" + val7 + "', N'" + val8 + "')";
    }

    public static string makeParam(string par1, string val1, string par2, string val2, string par3, string val3, string par4, string val4, string par5, string val5, string par6, string val6, string par7, string val7)
    {
        return " (" + par1 + "," + par2 + "," + par3 + "," + par4 + "," + par5 + "," + par6 + "," + par7 + ") VALUES (N'" + val1 + "', N'" + val2 + "', N'" + val3 + "', N'" + val4 + "', N'" + val5 + "', N'" + val6 + "', N'" + val7 + "')";
    }

    public static string makeParam(string par1, string val1, string par2, string val2, string par3, string val3, string par4, string val4, string par5, string val5, string par6, string val6, string par7, string val7, string par8, string val8, string par9, string val9)
    {
        return " (" + par1 + "," + par2 + "," + par3 + "," + par4 + "," + par5 + "," + par6 + "," + par7 + "," + par8 + "," + par9 + ") VALUES (N'" + val1 + "', N'" + val2 + "', N'" + val3 + "', N'" + val4 + "', N'" + val5 + "', N'" + val6 + "', N'" + val7 + "', N'" + val8 + "', N'" + val9 + "')";
    }

    public static string makeParam(
        string par1, string val1,
        string par2, string val2,
        string par3, string val3,
        string par4, string val4,
        string par5, string val5,
        string par6, string val6,
        string par7, string val7,
        string par8, string val8,
        string par9, string val9,
        string par10, string val10,
        string par11, string val11,
        string par12, string val12,
        string par13, string val13,
        string par14, string val14)
    {
        return " (" + par1 + "," + par2 + "," + par3 + "," + par4 + "," + par5 + "," + par6 + "," + par7 + "," + par8 + "," + par9 + "," + par10 + "," + par11 + "," + par12 + "," + par13 + "," + par14 + ") VALUES (N'" + val1 + "', N'" + val2 + "', N'" + val3 + "', N'" + val4 + "', N'" + val5 + "', N'" + val6 + "', N'" + val7 + "', N'" + val8 + "', N'" + val9 + "', N'" + val10 + "', N'" + val11 + "', N'" + val12 + "', N'" + val13 + "', N'" + val14 + "')";
    }

    public static string makeSet(
    string par1, string val1,
    string par2, string val2,
    string par3, string val3,
    string par4, string val4,
    string par5, string val5,
    string par6, string val6,
    string par7, string val7,
    string par8, string val8,
    string par9, string val9,
    string par10, string val10,
    string par11, string val11,
    string par12, string val12,
    string par13, string val13,
    string par14, string val14)
    {
        return " " + par1 + "=N'" + val1 + "', " + par2 + "=N'" + val2 + "', " + par3 + "=N'" + val3 + "', " + par4 + "=N'" + val4 + "', " + par5 + "=N'" + val5 + "', " + par6 + "=N'" + val6 + "', " + par7 + "=N'" + val7 + "', " + par8 + "=N'" + val8 + "', " + par9 + "=N'" + val9 + "', " + par10 + "=N'" + val10 + "', " + par11 + "=N'" + val11 + "', " + par12 + "=N'" + val12 + "', " + par13 + "=N'" + val13 + "', " + par14 + "=N'" + val14 + "'";
    }

    public static string makeSet(
    string par1, string val1,
    string par2, string val2,
    string par3, string val3,
    string par4, string val4,
    string par5, string val5,
    string par6, string val6,
    string par7, string val7)
    {
        return " " + par1 + "=N'" + val1 + "', " + par2 + "=N'" + val2 + "', " + par3 + "=N'" + val3 + "', " + par4 + "=N'" + val4 + "', " + par5 + "=N'" + val5 + "', " + par6 + "=N'" + val6 + "', " + par7 + "=N'" + val7 + "'";
    }

    public static string makeSet(
        string par1, string val1,
        string par2, string val2,
        string par3, string val3,
        string par4, string val4,
        string par5, string val5,
        string par6, string val6,
        string par7, string val7,
        string par8, string val8)
    {
        return " " + par1 + "=N'" + val1 + "', " + par2 + "=N'" + val2 + "', " + par3 + "=N'" + val3 + "', " + par4 + "=N'" + val4 + "', " + par5 + "=N'" + val5 + "', " + par6 + "=N'" + val6 + "', " + par7 + "=N'" + val7 + "', " + par8 + "=N'" + val8 + "'";
    }

    public static string makeSet(
        string par1, string val1)
    {
        return " " + par1 + "=N'" + val1 + "'";
    }

    public static string makeHtmlSet(
    string par1, string val1)
    {
        return " " + par1 + " values (@" + val1 + ")";
    }
    
    public static string makeSet(
        string par1, string val1,
        string par2, string val2)
    {
        return " " + par1 + "=N'" + val1 + "', " + par2 + "=N'" + val2 + "'";
    }

    public static string makeSet(
    string par1, string val1,
    string par2, string val2,
    string par3, string val3)
    {
        return " " + par1 + "=N'" + val1 + "', " + par2 + "=N'" + val2 + "', " + par3 + "=N'" + val3 + "'";
    }

    public static string makeSet(
        string par1,  string val1, 
        string par2,  string val2,
        string par3,  string val3,
        string par4,  string val4,
        string par5,  string val5,
        string par6,  string val6,
        string par7,  string val7,
        string par8,  string val8,
        string par9,  string val9,
        string par10, string val10,
        string par11, string val11,
        string par12, string val12,
        string par13, string val13,
        string par14, string val14,
        string par15, string val15,
        string par16, string val16,
        string par17, string val17,
        string par18, string val18,
        string par19, string val19,
        string par20, string val20,
        string par21, string val21,
        string par22, string val22,
        string par23, string val23, 
        string par24, string val24)
    {
        return " " + par1 + "='" + val1 + "', " + par2 + "='" + val2 + "', " + par3 + "='" + val3 + "', " + par4 + "='" + val4 + "', " + par5 + "='" + val5 + "', " + par6 + "='" + val6 + "', " + par7 + "='" + val7 + "', " + par8 + "='" + val8 + "', " + par9 + "='" + val9 + "', " + par10 + "='" + val10 + "', " + par11 + "='" + val11 + "', " + par12 + "='" + val12 + "', " + par13 + "='" + val13 + "', " + par14 + "='" + val14 + "', " + par15 + "='" + val15 + "', " + par16 + "='" + val16 + "', " + par17 + "='" + val17 + "', " + par18 + "='" + val18 + "', " + par19 + "='" + val19 + "', " + par20 + "='" + val20 + "', " + par21 + "='" + val21 + "', " + par22 + "='" + val22 + "', " + par23 + "='" + val23 + "', " + par24 + "='" + val24 + "'";
    }

    public static string Insert(string table, string makeparam)
    {
        return "INSERT INTO " + table + " " + makeparam;
    }

    public static string Update(string table_name, string makeSet, string makeWhere)
    {
        return "UPDATE " + table_name + " SET " + makeSet + " " + makeWhere;
    }

    private static Random rand = new Random();

    public static string creatUpdateTime()
    {
        return rand.NextDouble().ToString().Replace("0.", "");
    }

    public static string SelectLast(string table_name, string column_name)
    {
        return "SELECT MAX(" + column_name + ")  FROM " + table_name + "";
    }

    public static string SelectFirst(string table_name, string column_name)
    {
        return "SELECT MIN(" + column_name + ")  FROM " + table_name + "";
    }

    public static string Delete(string table_name, string makeWhere)
    {
        return "DELETE FROM " + table_name + " " + makeWhere + ";";
    }

    public static string GROUPBY(string title)
    {
        return " GROUP BY " + title;
    }

    public static string SelectDISTINCT(string TABLE_NAME, string col_name)
    {
        return "SELECT DISTINCT " + col_name + " FROM " + TABLE_NAME;
    }

    public static string CreateTime()
    {
        string createdTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt");
        return createdTime;
    }

    public static string LastId(string TABLE_NAME)
    {
        return "SELECT * FROM " + TABLE_NAME + " WHERE ID = (SELECT MAX(id)  FROM " + TABLE_NAME + ");";
    }

    public static string SelectBetweenId_to_Last(string TABLE_NAME, string id)
    {
        return "SELECT * FROM " + TABLE_NAME + " WHERE [id] BETWEEN " + id + " AND (SELECT MAX(id)  FROM " + TABLE_NAME + ") order by [id];";
    }

    public static string SelectBetweenId_to_Last_by_imei(string TABLE_NAME, string id, string IMEI)
    {
        return "SELECT * FROM " + TABLE_NAME + " WHERE [id] BETWEEN " + id + " AND (SELECT MAX(id)  FROM " + TABLE_NAME + ") and [user_id] = N'" + IMEI + "' order by [id];";
    }

    internal static string makeSet(string par1, long val1, string par2, string val2)
    {
        return " " + par1 + "=" + val1 + ", " + par2 + "=N'" + val2 + "'";
    }
}
