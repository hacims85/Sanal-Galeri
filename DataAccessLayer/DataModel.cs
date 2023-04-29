using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Member Transactions

        public List<Members> ListMembers()
        {
            List<Members> members = new List<Members>();
            try
            {
                cmd.CommandText = "SELECT mem.ID,mem.Name,mem.Surname,mem.MembershipStatus_ID,ms.Name,mem.ProfilPhoto,mem.Info,mem.Email,mem.Birthday,mem.UserName,mem.UserPassword,mem.SecurityQestions_ID,sq.Qestions,mem.SecurityAnswer,mem.VisitorCounts,mem.RegistrationDate,mem.UserStatus FROM Members AS mem JOIN MembershipStatus AS ms ON mem.MembershipStatus_ID=ms.ID JOIN SecurityQestions AS sq ON mem.SecurityQestions_ID=sq.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Members mem = new Members();
                    mem.ID = reader.GetInt32(0);
                    mem.Name = reader.GetString(1);
                    mem.Surname = reader.GetString(2);
                    mem.MembershipStatusID = reader.GetInt32(3);
                    mem.MembershipStatusName = reader.GetString(4);
                    mem.ProfilPhoto = !reader.IsDBNull(5) ? reader.GetString(5) : "none.png";
                    mem.Info = reader.GetString(6);
                    mem.Email = reader.GetString(7);
                    mem.BirthdayStr = reader.GetDateTime(8).ToShortDateString();
                    mem.UserName = reader.GetString(9);
                    mem.UserPassword = reader.GetString(10);
                    mem.SecurityQestionsID = reader.GetInt32(11);
                    mem.SecurityQestionsQestion = reader.GetString(12);
                    mem.SecurityAnswer = reader.GetString(13);
                    mem.VisitorCounts = reader.GetInt32(14);
                    mem.RegistrationDate = reader.GetDateTime(15);
                    mem.RegistrationDateStr = reader.GetDateTime(15).ToShortDateString();
                    mem.RegistrationTimeStr = reader.GetDateTime(15).ToShortTimeString();
                    mem.UserStatusStr = reader.GetBoolean(16) ? "<label style='color:green'>Aktif</label>" : "<label style='color:gray'>Pasif</label>";
                    members.Add(mem);
                }
                return members;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public bool ChangeMemberStatus(int mid, int msid)
        {
            try
            {
                cmd.CommandText = "UPDATE Members SET MembershipStatus_ID = @msid WHERE ID=@mid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mid", mid);
                cmd.Parameters.AddWithValue("@msid", msid);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public Members GetMemberByID(int memid)
        {
            try
            {
                cmd.CommandText = "SELECT mem.ID,mem.Name,mem.Surname,mem.MembershipStatus_ID,ms.Name,mem.ProfilPhoto,mem.Info,mem.Email,mem.Birthday,mem.UserName,mem.UserPassword,mem.SecurityQestions_ID,sq.Qestions,mem.SecurityAnswer,mem.VisitorCounts,mem.RegistrationDate,mem.UserStatus FROM Members AS mem JOIN MembershipStatus AS ms ON mem.MembershipStatus_ID=ms.ID JOIN SecurityQestions AS sq ON mem.SecurityQestions_ID=sq.ID WHERE mem.ID=@memid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@memid", memid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Members mem = new Members();
                while (reader.Read())
                {
                    mem.ID = reader.GetInt32(0);
                    mem.Name = reader.GetString(1);
                    mem.Surname = reader.GetString(2);
                    mem.MembershipStatusID = reader.GetInt32(3);
                    mem.MembershipStatusName = reader.GetString(4);
                    mem.ProfilPhoto = !reader.IsDBNull(5) ? reader.GetString(5) : "none.png";
                    mem.Info = reader.GetString(6);
                    mem.Email = reader.GetString(7);
                    mem.BirthdayStr = reader.GetDateTime(8).ToShortDateString();
                    mem.UserName = reader.GetString(9);
                    mem.UserPassword = reader.GetString(10);
                    mem.SecurityQestionsID = reader.GetInt32(11);
                    mem.SecurityQestionsQestion = reader.GetString(12);
                    mem.SecurityAnswer = reader.GetString(13);
                    mem.VisitorCounts = reader.GetInt32(14);
                    mem.RegistrationDate = reader.GetDateTime(15);
                    mem.RegistrationDateStr = reader.GetDateTime(15).ToShortDateString();
                    mem.RegistrationTimeStr = reader.GetDateTime(15).ToShortTimeString();
                    mem.UserStatusStr = reader.GetBoolean(16) ? "<label style='color:green'>Aktif</label>" : "<label style='color:gray'>Pasif</label>";
                }
                return mem;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }


        #endregion
        #region ArtCategories Transactions
        public List<ArtCategories> ListArtCategories()
        {
            List<ArtCategories> artCategories = new List<ArtCategories>();
            try
            {
                cmd.CommandText = "SELECT * FROM ArtCategories";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ArtCategories a = new ArtCategories();
                    a.ID = reader.GetInt32(0);
                    a.Name = reader.GetString(1);
                    a.ArtCategoriesStatusStr = reader.GetBoolean(2) ? "<label style='color:green'>Aktif</label>" : "<label style='color:gray'>Pasif</label>";
                    artCategories.Add(a);
                }
                return artCategories;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public bool AddArtCategories(ArtCategories a)
        {
            try
            {
                cmd.CommandText = "INSERT INTO ArtCategories(Name, ArtCategoriesStatus) VALUES(@name, @status)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", a.Name);
                cmd.Parameters.AddWithValue("@status", a.ArtCategoriesStatus);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public bool DeleteArtCategories(int acid)
        {
            try
            {
                cmd.CommandText = "DELETE FROM ArtCategories WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", acid);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public ArtCategories GetArtCategories(int acid)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM ArtCategories WHERE ID=@acid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@acid", acid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ArtCategories ac = new ArtCategories();
                while (reader.Read())
                {
                    ac.ID = reader.GetInt32(0);
                    ac.Name = reader.GetString(1);
                    ac.ArtCategoriesStatus = reader.GetBoolean(2);
                    ac.ArtCategoriesStatusStr = reader.GetBoolean(2) ? "<label style='color:green'>Aktif</label>" : "<label style='color:gray'>Pasif</label>";

                }
                return ac;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        public bool ArtCategoriesNameUpdate(ArtCategories ac)
        {
            try
            {
                cmd.CommandText = "UPDATE ArtCategories SET NAME = @name WHERE ID=@acid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", ac.Name);
                cmd.Parameters.AddWithValue("@acid", ac.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public bool ActivateArtCategories(int acid)
        {
            try
            {
                cmd.CommandText = "UPDATE ArtCategories SET ArtCategoriesStatus = 1 WHERE ID=@acid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@acid", acid);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public bool DisableArtCategories(int acid)
        {
            try
            {
                cmd.CommandText = "UPDATE ArtCategories SET ArtCategoriesStatus = 0 WHERE ID=@acid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@acid", acid);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }

        #endregion
        #region Comments Transactions
        public List<Comments> ListCommentsAccepted(int ansid)
        {
            List<Comments> comments = new List<Comments>();
            try
            {
                cmd.CommandText = "SELECT C.ID,C.Contents,C.Artwork_ID,Aw.Name,C.Writer_ID,M.Name,M.UserName,C.Comments_ID,C.LikeCounts,C.DislikeCounts,C.ViewsCounts,C.UploadDate,C.Approver_ID,AP.Name,AP.UserName,C.ApprovedDate,C.AnswerStatus_ID,Ans.Name FROM Comments As C JOIN Artworks AS Aw ON C.Artwork_ID=Aw.ID JOIN Members AS M ON C.Writer_ID=M.ID JOIN Members AS AP ON C.Approver_ID=AP.ID JOIN AnswerStatus AS Ans ON C.AnswerStatus_ID=Ans.ID WHERE C.AnswerStatus_ID=@ansid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ansid", ansid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comments c = new Comments();
                    c.ID = reader.GetInt32(0);
                    c.Contents = reader.GetString(1);
                    c.ArtworkID = reader.GetInt32(2);
                    c.ArtworkName = reader.GetString(3);
                    c.WriterID = reader.GetInt32(4);
                    c.WriterName = reader.GetString(5);
                    c.WriterUserName = reader.GetString(6);
                    c.CommentsID = !reader.IsDBNull(7) ? reader.GetInt32(7) : 0;
                    c.LikeCounts = reader.GetInt32(8);
                    c.DislikeCounts = reader.GetInt32(9);
                    c.ViewsCounts = reader.GetInt32(10);
                    c.UploadDate = reader.GetDateTime(11);
                    c.UploadDateStr = reader.GetDateTime(11).ToShortDateString();
                    c.UploadTimeStr = reader.GetDateTime(11).ToShortTimeString();
                    c.ApproverID = reader.GetInt32(12);
                    c.ApproverName = reader.GetString(13);
                    c.ApproverUserName = reader.GetString(14);
                    c.ApprovedDate = reader.GetDateTime(15);
                    c.ApprovedDateStr = reader.GetDateTime(15).ToShortDateString();
                    c.ApprovedTimeStr = reader.GetDateTime(15).ToShortTimeString();
                    c.AnswerStatusID = reader.GetInt32(16);
                    c.AnswerStatusName = reader.GetString(17);
                    comments.Add(c);
                }
                return comments;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Comments> ListCommentsAccepted()
        {
            List<Comments> comments = new List<Comments>();
            try
            {
                cmd.CommandText = "SELECT C.ID,C.Contents,C.Artwork_ID,Aw.Name,C.Writer_ID,M.Name,M.UserName,C.Comments_ID,C.LikeCounts,C.DislikeCounts,C.ViewsCounts,C.UploadDate,C.Approver_ID,AP.Name,AP.UserName,C.ApprovedDate,C.AnswerStatus_ID,Ans.Name FROM Comments As C JOIN Artworks AS Aw ON C.Artwork_ID=Aw.ID JOIN Members AS M ON C.Writer_ID=M.ID JOIN Members AS AP ON C.Approver_ID=AP.ID JOIN AnswerStatus AS Ans ON C.AnswerStatus_ID=Ans.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comments c = new Comments();
                    c.ID = reader.GetInt32(0);
                    c.Contents = reader.GetString(1);
                    c.ArtworkID = reader.GetInt32(2);
                    c.ArtworkName = reader.GetString(3);
                    c.WriterID = reader.GetInt32(4);
                    c.WriterName = reader.GetString(5);
                    c.WriterUserName = reader.GetString(6);
                    c.CommentsID = !reader.IsDBNull(7) ? reader.GetInt32(7) : 0;
                    c.LikeCounts = reader.GetInt32(8);
                    c.DislikeCounts = reader.GetInt32(9);
                    c.ViewsCounts = reader.GetInt32(10);
                    c.UploadDate = reader.GetDateTime(11);
                    c.UploadDateStr = reader.GetDateTime(11).ToShortDateString();
                    c.UploadTimeStr = reader.GetDateTime(11).ToShortTimeString();
                    c.ApproverID = reader.GetInt32(12);
                    c.ApproverName = reader.GetString(13);
                    c.ApproverUserName = reader.GetString(14);
                    c.ApprovedDate = reader.GetDateTime(15);
                    c.ApprovedDateStr = reader.GetDateTime(15).ToShortDateString();
                    c.ApprovedTimeStr = reader.GetDateTime(15).ToShortTimeString();
                    c.AnswerStatusID = reader.GetInt32(16);
                    c.AnswerStatusName = reader.GetString(17);
                    comments.Add(c);
                }
                return comments;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Comments> ListCommentsNotAccepted(int aid)
        {
            List<Comments> comments = new List<Comments>();
            try
            {
                cmd.CommandText = "SELECT C.ID,C.Contents,C.Artwork_ID,Aw.Name,C.Writer_ID,M.UserName,M.Name,C.Comments_ID,C.UploadDate,C.AnswerStatus_ID,Ans.Name FROM Comments As C JOIN Artworks AS Aw ON C.Artwork_ID=Aw.ID JOIN Members AS M ON C.Writer_ID=M.ID JOIN AnswerStatus AS Ans ON C.AnswerStatus_ID=Ans.ID WHERE C.AnswerStatus_ID=@ansid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ansid", aid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comments c = new Comments();
                    c.ID = reader.GetInt32(0);
                    c.Contents = reader.GetString(1);
                    c.ArtworkID = reader.GetInt32(2);
                    c.ArtworkName = reader.GetString(3);
                    c.WriterID = reader.GetInt32(4);
                    c.WriterUserName = reader.GetString(5);
                    c.WriterName = reader.GetString(6);
                    c.CommentsID = !reader.IsDBNull(7) ? reader.GetInt32(7) : 0;
                    c.UploadDate = reader.GetDateTime(8);
                    c.UploadDateStr = reader.GetDateTime(8).ToShortDateString();
                    c.UploadTimeStr = reader.GetDateTime(8).ToShortTimeString();
                    c.AnswerStatusID = reader.GetInt32(9);
                    c.AnswerStatusName = reader.GetString(10);
                    comments.Add(c);
                }
                return comments;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Comments> ListCommentsNotAccepted()
        {
            List<Comments> comments = new List<Comments>();
            try
            {
                cmd.CommandText = "SELECT C.ID,C.Contents,C.Artwork_ID,Aw.Name,C.Writer_ID,M.UserName,M.Name,C.Comments_ID,C.UploadDate,C.AnswerStatus_ID,Ans.Name FROM Comments As C JOIN Artworks AS Aw ON C.Artwork_ID=Aw.ID JOIN Members AS M ON C.Writer_ID=M.ID JOIN AnswerStatus AS Ans ON C.AnswerStatus_ID=Ans.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comments c = new Comments();
                    c.ID = reader.GetInt32(0);
                    c.Contents = reader.GetString(1);
                    c.ArtworkID = reader.GetInt32(2);
                    c.ArtworkName = reader.GetString(3);
                    c.WriterID = reader.GetInt32(4);
                    c.WriterUserName = reader.GetString(5);
                    c.WriterName = reader.GetString(6);
                    c.CommentsID = !reader.IsDBNull(7) ? reader.GetInt32(7) : 0;
                    c.UploadDate = reader.GetDateTime(8);
                    c.UploadDateStr = reader.GetDateTime(8).ToShortDateString();
                    c.UploadTimeStr = reader.GetDateTime(8).ToShortTimeString();
                    c.AnswerStatusID = reader.GetInt32(9);
                    c.AnswerStatusName = reader.GetString(10);
                    comments.Add(c);
                }
                return comments;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Comments> Top10Comments()
        {
            List<Comments> comments = new List<Comments>();
            try
            {
                cmd.CommandText = "SELECT TOP(10) C.ID,C.Contents,C.Artwork_ID,Aw.Name,C.Writer_ID,M.Name,C.Comments_ID,C.LikeCounts,C.DislikeCounts,C.ViewsCounts,C.UploadDate,C.Approver_ID,M.Name,C.ApprovedDate,C.AnswerStatus_ID,Ans.Name FROM Comments As C JOIN Artworks AS Aw ON C.Artwork_ID=Aw.ID JOIN Members AS M ON C.Writer_ID=M.ID JOIN AnswerStatus AS Ans ON C.AnswerStatus_ID=Ans.ID ORDER BY C.LikeCounts DESC";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comments c = new Comments();
                    c.ID = reader.GetInt32(0);
                    c.Contents = reader.GetString(1);
                    c.ArtworkID = reader.GetInt32(2);
                    c.ArtworkName = reader.GetString(3);
                    c.WriterID = reader.GetInt32(4);
                    c.WriterName = reader.GetString(5);
                    c.CommentsID = !reader.IsDBNull(6) ? reader.GetInt32(6) : 0;
                    c.LikeCounts = reader.GetInt32(7);
                    c.DislikeCounts = reader.GetInt32(8);
                    c.ViewsCounts = reader.GetInt32(9);
                    c.UploadDateStr = reader.GetDateTime(10).ToShortDateString();
                    c.UploadTimeStr = reader.GetDateTime(10).ToShortTimeString();
                    c.ApproverID = reader.GetInt32(12);
                    c.ApproverName = reader.GetString(13);
                    c.ApprovedDateStr = reader.GetDateTime(14).ToShortDateString();
                    c.ApprovedTimeStr = reader.GetDateTime(14).ToShortTimeString();
                    c.AnswerStatusID = reader.GetInt32(16);
                    c.AnswerStatusName = reader.GetString(17);
                    comments.Add(c);
                }
                return comments;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { con.Close(); }
        }
        public bool UpdateComments(Comments c)
        {
            try
            {
                cmd.Parameters.Clear();
                if (c.CommentsID == 0)
                {
                    cmd.CommandText = "UPDATE Comments SET Contents=@contents, Artwork_ID=@awid, Writer_ID=@wid, LikeCounts=@likecounts, DislikeCounts=@dislikecounts, ViewsCounts=@viewscounts, UploadDate=@uploaddate, Approver_ID=@appid, ApprovedDate=@approveddate, AnswerStatus_ID=@ansid WHERE ID=@id";
                }
                else
                {
                    cmd.CommandText = "UPDATE Comments SET Contents=@contents, Artwork_ID=@awid, Writer_ID=@wid, Comments_ID=@comid, LikeCounts=@likecounts, DislikeCounts=@dislikecounts, ViewsCounts=@viewscounts, UploadDate=@uploaddate, Approver_ID=@appid, ApprovedDate=@approveddate, AnswerStatus_ID=@ansid WHERE ID=@id";
                    cmd.Parameters.AddWithValue("@comid", c.CommentsID);
                }

                cmd.Parameters.AddWithValue("@contents", c.Contents);
                cmd.Parameters.AddWithValue("@awid", c.ArtworkID);
                cmd.Parameters.AddWithValue("@wid", c.WriterID);
                cmd.Parameters.AddWithValue("@likecounts", c.LikeCounts);
                cmd.Parameters.AddWithValue("@dislikecounts", c.DislikeCounts);
                cmd.Parameters.AddWithValue("@viewscounts", c.ViewsCounts);
                cmd.Parameters.AddWithValue("@uploaddate", c.UploadDate);
                cmd.Parameters.AddWithValue("@appid", c.ApproverID);
                cmd.Parameters.AddWithValue("@approveddate", c.ApprovedDate);
                cmd.Parameters.AddWithValue("@ansid", c.AnswerStatusID);
                cmd.Parameters.AddWithValue("@id", c.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public bool CommentsEntry(Comments c)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Comments(Contents,Artwork_ID,Writer_ID,Comments_ID,LikeCounts,DislikeCounts,ViewsCounts,UploadDate) VALUES(@contents,@awid,@wid,@comid,@likecounts,@dislikecounts,@viewscounts,@uploaddate)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@contents", c.Contents);
                cmd.Parameters.AddWithValue("@awid", c.ArtworkID);
                cmd.Parameters.AddWithValue("@wid", c.WriterID);
                cmd.Parameters.AddWithValue("@comid", c.CommentsID);
                cmd.Parameters.AddWithValue("@likecounts", c.LikeCounts);
                cmd.Parameters.AddWithValue("@dislikecounts", c.DislikeCounts);
                cmd.Parameters.AddWithValue("@viewscounts", c.ViewsCounts);
                cmd.Parameters.AddWithValue("@uploaddate", c.UploadDate);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }

        }
        public Comments GetCommentsNotAccepted(int cid)
        {
            try
            {
                cmd.CommandText = "SELECT C.ID,C.Contents,C.Artwork_ID,Aw.Name,C.Writer_ID,M.UserName,M.Name,C.Comments_ID,C.UploadDate,C.AnswerStatus_ID,Ans.Name FROM Comments As C JOIN Artworks AS Aw ON C.Artwork_ID=Aw.ID JOIN Members AS M ON C.Writer_ID=M.ID JOIN AnswerStatus AS Ans ON C.AnswerStatus_ID=Ans.ID WHERE C.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", cid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Comments c = new Comments();
                while (reader.Read())
                {
                    c.ID = reader.GetInt32(0);
                    c.Contents = reader.GetString(1);
                    c.ArtworkID = reader.GetInt32(2);
                    c.ArtworkName = reader.GetString(3);
                    c.WriterID = reader.GetInt32(4);
                    c.WriterUserName = reader.GetString(5);
                    c.WriterName = reader.GetString(6);
                    c.CommentsID = !reader.IsDBNull(7) ? reader.GetInt32(7) : 0;
                    c.UploadDate = reader.GetDateTime(8);
                    c.UploadDateStr = reader.GetDateTime(8).ToShortDateString();
                    c.UploadTimeStr = reader.GetDateTime(8).ToShortTimeString();
                    c.AnswerStatusID = reader.GetInt32(9);
                    c.AnswerStatusName = reader.GetString(10);
                }
                return c;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public Comments GetCommentsAccepted(int cid)
        {
            try
            {
                cmd.CommandText = "SELECT C.ID,C.Contents,C.Artwork_ID,Aw.Name,C.Writer_ID,M.Name,M.UserName,C.Comments_ID,C.LikeCounts,C.DislikeCounts,C.ViewsCounts,C.UploadDate,C.Approver_ID,AP.Name,AP.UserName,C.ApprovedDate,C.AnswerStatus_ID,Ans.Name FROM Comments As C JOIN Artworks AS Aw ON C.Artwork_ID=Aw.ID JOIN Members AS M ON C.Writer_ID=M.ID JOIN Members AS AP ON C.Approver_ID=AP.ID JOIN AnswerStatus AS Ans ON C.AnswerStatus_ID=Ans.ID WHERE C.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", cid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Comments c = new Comments();
                while (reader.Read())
                {
                    c.ID = reader.GetInt32(0);
                    c.Contents = reader.GetString(1);
                    c.ArtworkID = reader.GetInt32(2);
                    c.ArtworkName = reader.GetString(3);
                    c.WriterID = reader.GetInt32(4);
                    c.WriterName = reader.GetString(5);
                    c.WriterUserName = reader.GetString(6);
                    c.CommentsID = !reader.IsDBNull(7) ? reader.GetInt32(7) : 0;
                    c.LikeCounts = reader.GetInt32(8);
                    c.DislikeCounts = reader.GetInt32(9);
                    c.ViewsCounts = reader.GetInt32(10);
                    c.UploadDateStr = reader.GetDateTime(11).ToShortDateString();
                    c.UploadTimeStr = reader.GetDateTime(11).ToShortTimeString();
                    c.ApproverID = reader.GetInt32(12);
                    c.ApproverName = reader.GetString(13);
                    c.ApproverUserName = reader.GetString(14);
                    c.ApprovedDateStr = reader.GetDateTime(15).ToShortDateString();
                    c.ApprovedTimeStr = reader.GetDateTime(15).ToShortTimeString();
                    c.AnswerStatusID = reader.GetInt32(16);
                    c.AnswerStatusName = reader.GetString(17);
                }
                return c;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }

        }
        public bool CommentsSoftDelete(int cid)
        {
            try
            {
                cmd.CommandText = "UPDATE Comments SET CommentStatus=0 WHERE ID=@cid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cid", cid);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public bool SoftDeleteAnswers(int cid)
        {
            try
            {
                cmd.CommandText = "UPDATE Comments SET CommentStatus=0 WHERE Comments_ID=@cid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cid", cid);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        #endregion
        #region Complaints Transactions

        public List<Complaints> ListComplaints()
        {
            try
            {
                List<Complaints> complaints = new List<Complaints>();
                cmd.CommandText = "SELECT C.ID,C.Explanation,C.ComplaintReason_ID,CR.Reason,C.Comment_ID,COM.Contents,C.Artwork_ID,AW.Name,C.Member_ID,M.UserName,C.Complainant_ID,CM.UserName,C.AnswerStatus_ID,ANS.Name,C.ComplaintDate FROM Complaints AS C JOIN ComplaintReasons AS CR ON C.ComplaintReason_ID=CR.ID JOIN Comments AS COM ON C.Comment_ID=COM.ID JOIN Artworks AS AW ON C.Artwork_ID=AW.ID JOIN Members AS M on C.Member_ID=M.ID JOIN Members AS CM ON C.Complainant_ID=CM.ID JOIN AnswerStatus AS Ans ON C.AnswerStatus_ID=Ans.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Complaints c = new Complaints();
                    c.ID = reader.GetInt32(0);
                    c.Explanation = reader.GetString(1);
                    c.ComplaintReasonID = reader.GetInt32(2);
                    c.ComplaintReason = reader.GetString(3);
                    c.CommentID = reader.GetInt32(4);
                    c.CommentContent = reader.GetString(5);
                    c.ArtworkID = reader.GetInt32(6);
                    c.ArtworkName = reader.GetString(7);
                    c.MemberID = reader.GetInt32(8);
                    c.MemberUserName = reader.GetString(9);
                    c.ComplainantID = reader.GetInt32(10);
                    c.ComplainantUserName = reader.GetString(11);
                    c.AnswerStatusID = reader.GetInt32(12);
                    c.AnswerStatusName = reader.GetString(13);
                    c.ComplainantDate = reader.GetDateTime(14);
                    c.ComplainantDateStr = reader.GetDateTime(14).ToShortDateString();
                    c.ComplainantTimeStr = reader.GetDateTime(14).ToShortTimeString();

                }

                return complaints;

            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        public List<Complaints> ListComplaints(int ansid)
        {
            try
            {
                List<Complaints> complaints = new List<Complaints>();
                cmd.CommandText = "SELECT C.ID,C.Explanation,C.ComplaintReason_ID,CR.Reason,C.Comment_ID,COM.Contents,C.Artwork_ID,AW.Name,C.Member_ID,M.UserName,C.Complainant_ID,CM.UserName,C.AnswerStatus_ID,ANS.Name,C.ComplaintDate FROM Complaints AS C JOIN ComplaintReasons AS CR ON C.ComplaintReason_ID=CR.ID JOIN Comments AS COM ON C.Comment_ID=COM.ID JOIN Artworks AS AW ON C.Artwork_ID=AW.ID JOIN Members AS M on C.Member_ID=M.ID JOIN Members AS CM ON C.Complainant_ID=CM.ID JOIN AnswerStatus AS Ans ON C.AnswerStatus_ID=Ans.ID WHERE Ans.ID=@aid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@aid", ansid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Complaints c = new Complaints();
                    c.ID = reader.GetInt32(0);
                    c.Explanation = reader.GetString(1);
                    c.ComplaintReasonID = reader.GetInt32(2);
                    c.ComplaintReason = reader.GetString(3);
                    c.CommentID = reader.GetInt32(4);
                    c.CommentContent = reader.GetString(5);
                    c.ArtworkID = reader.GetInt32(6);
                    c.ArtworkName = reader.GetString(7);
                    c.MemberID = reader.GetInt32(8);
                    c.MemberUserName = reader.GetString(9);
                    c.ComplainantID = reader.GetInt32(10);
                    c.ComplainantUserName = reader.GetString(11);
                    c.AnswerStatusID = reader.GetInt32(12);
                    c.AnswerStatusName = reader.GetString(13);
                    c.ComplainantDate = reader.GetDateTime(14);
                    c.ComplainantDateStr = reader.GetDateTime(14).ToShortDateString();
                    c.ComplainantTimeStr = reader.GetDateTime(14).ToShortTimeString();

                }

                return complaints;

            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        public List<Complaints> ListCommendComplaintsNotAccepted()
        {
            List<Complaints> list = new List<Complaints>();
            try
            {
                cmd.CommandText = "SELECT com.ID,com.Explanation,com.ComplaintReason_ID,cr.Reason,com.Comment_ID,c.Contents,com.Complainant_ID,cm.Name,cm.UserName,com.AnswerStatus_ID,ans.Name,com.ComplaintDate FROM Complaints AS com JOIN ComplaintReasons AS cr ON com.ComplaintReason_ID=cr.ID JOIN Comments AS c ON com.Comment_ID=c.ID JOIN Members AS cm ON com.Complainant_ID=cm.ID JOIN AnswerStatus AS ans ON com.AnswerStatus_ID=ans.ID WHERE com.AnswerStatus_ID=1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Complaints com = new Complaints();
                    com.ID = reader.GetInt32(0);
                    com.Explanation = reader.GetString(1);
                    com.ComplaintReasonID = reader.GetInt32(2);
                    com.ComplaintReason = reader.GetString(3);
                    com.CommentID = reader.GetInt32(4);
                    com.CommentContent = reader.GetString(5);
                    com.ComplainantID = reader.GetInt32(6);
                    com.ComplainantName = reader.GetString(7);
                    com.ComplainantUserName = reader.GetString(8);
                    com.AnswerStatusID = reader.GetInt32(9);
                    com.AnswerStatusName = reader.GetString(10);
                    com.ComplainantDate = reader.GetDateTime(11);
                    com.ComplainantDateStr = reader.GetDateTime(11).ToShortDateString();
                    com.ComplainantTimeStr = reader.GetDateTime(11).ToShortTimeString();
                    list.Add(com);
                }
                return list;

            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Complaints> ListCommendComplaintsNotAccepted(int ansid)
        {
            List<Complaints> list = new List<Complaints>();
            try
            {
                cmd.CommandText = "SELECT com.ID,com.Explanation,com.ComplaintReason_ID,cr.Reason,com.Comment_ID,c.Contents,com.Complainant_ID,cm.Name,cm.UserName,com.AnswerStatus_ID,ans.Name,com.ComplaintDate FROM Complaints AS com JOIN ComplaintReasons AS cr ON com.ComplaintReason_ID=cr.ID JOIN Comments AS c ON com.Comment_ID=c.ID JOIN Members AS cm ON com.Complainant_ID=cm.ID JOIN AnswerStatus AS ans ON com.AnswerStatus_ID=ans.ID WHERE com.AnswerStatus_ID=@ansid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ansid", ansid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Complaints com = new Complaints();
                    com.ID = reader.GetInt32(0);
                    com.Explanation = reader.GetString(1);
                    com.ComplaintReasonID = reader.GetInt32(2);
                    com.ComplaintReason = reader.GetString(3);
                    com.CommentID = reader.GetInt32(4);
                    com.CommentContent = reader.GetString(5);
                    com.ComplainantID = reader.GetInt32(6);
                    com.ComplainantName = reader.GetString(7);
                    com.ComplainantUserName = reader.GetString(8);
                    com.AnswerStatusID = reader.GetInt32(9);
                    com.AnswerStatusName = reader.GetString(10);
                    com.ComplainantDate = reader.GetDateTime(11);
                    com.ComplainantDateStr = reader.GetDateTime(11).ToShortDateString();
                    com.ComplainantTimeStr = reader.GetDateTime(11).ToShortTimeString();
                    list.Add(com);
                }
                return list;

            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Complaints> ListCommendComplaintsNotAcceptedCommendStatus(int cstatus)
        {
            List<Complaints> list = new List<Complaints>();
            try
            {
                cmd.CommandText = "SELECT com.ID,com.Explanation,com.ComplaintReason_ID,cr.Reason,com.Comment_ID,c.CommentStatus,com.Complainant_ID,cm.Name,cm.UserName,com.AnswerStatus_ID,ans.Name,com.ComplaintDate FROM Complaints AS com JOIN ComplaintReasons AS cr ON com.ComplaintReason_ID=cr.ID JOIN Comments AS c ON com.Comment_ID=c.ID JOIN Members AS cm ON com.Complainant_ID=cm.ID JOIN AnswerStatus AS ans ON com.AnswerStatus_ID=ans.ID WHERE com.AnswerStatus_ID=1 c.CommentStatus=@cstatus";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ansid", cstatus);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Complaints com = new Complaints();
                    com.ID = reader.GetInt32(0);
                    com.Explanation = reader.GetString(1);
                    com.ComplaintReasonID = reader.GetInt32(2);
                    com.ComplaintReason = reader.GetString(3);
                    com.CommentID = reader.GetInt32(4);
                    com.CommentStatus = reader.GetBoolean(5);
                    com.ComplainantID = reader.GetInt32(6);
                    com.ComplainantName = reader.GetString(7);
                    com.ComplainantUserName = reader.GetString(8);
                    com.AnswerStatusID = reader.GetInt32(9);
                    com.AnswerStatusName = reader.GetString(10);
                    com.ComplainantDate = reader.GetDateTime(11);
                    com.ComplainantDateStr = reader.GetDateTime(11).ToShortDateString();
                    com.ComplainantTimeStr = reader.GetDateTime(11).ToShortTimeString();
                    list.Add(com);
                }
                return list;

            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Complaints> ListArtworkComplaintsNotAccepted()
        {
            List<Complaints> list = new List<Complaints>();
            try
            {
                cmd.CommandText = "SELECT com.ID,com.Explanation,com.ComplaintReason_ID,cr.Reason,com.Artwork_ID,aw.Name,com.Complainant_ID,cm.Name,cm.UserName,com.AnswerStatus_ID,ans.Name,com.ComplaintDate FROM Complaints AS com JOIN ComplaintReasons AS cr ON com.ComplaintReason_ID=cr.ID JOIN Artworks AS aw ON com.Artwork_ID=aw.ID JOIN Members AS cm ON com.Complainant_ID=cm.ID JOIN AnswerStatus AS ans ON com.AnswerStatus_ID=ans.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Complaints com = new Complaints();
                    com.ID = reader.GetInt32(0);
                    com.Explanation = reader.GetString(1);
                    com.ComplaintReasonID = reader.GetInt32(2);
                    com.ComplaintReason = reader.GetString(3);
                    com.ArtworkID = reader.GetInt32(4);
                    com.ArtworkName = reader.GetString(5);
                    com.ComplainantID = reader.GetInt32(6);
                    com.ComplainantName = reader.GetString(7);
                    com.ComplainantUserName = reader.GetString(8);
                    com.AnswerStatusID = reader.GetInt32(9);
                    com.AnswerStatusName = reader.GetString(10);
                    com.ComplainantDateStr = reader.GetDateTime(11).ToShortDateString();
                    com.ComplainantTimeStr = reader.GetDateTime(11).ToShortTimeString();
                    list.Add(com);
                }

                return list;

            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Complaints> ListArtworkComplaintsNotAccepted(int ansid)
        {
            List<Complaints> list = new List<Complaints>();
            try
            {
                cmd.CommandText = "SELECT com.ID,com.Explanation,com.ComplaintReason_ID,cr.Reason,com.Artwork_ID,aw.Name,com.Complainant_ID,cm.Name,cm.UserName,com.AnswerStatus_ID,ans.Name,com.ComplaintDate FROM Complaints AS com JOIN ComplaintReasons AS cr ON com.ComplaintReason_ID=cr.ID JOIN Artworks AS aw ON com.Artwork_ID=aw.ID JOIN Members AS cm ON com.Complainant_ID=cm.ID JOIN AnswerStatus AS ans ON com.AnswerStatus_ID=ans.ID WHERE com.AnswerStatus_ID=@ansid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ansid", ansid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Complaints com = new Complaints();
                    com.ID = reader.GetInt32(0);
                    com.Explanation = reader.GetString(1);
                    com.ComplaintReasonID = reader.GetInt32(2);
                    com.ComplaintReason = reader.GetString(3);
                    com.ArtworkID = reader.GetInt32(4);
                    com.ArtworkName = reader.GetString(5);
                    com.ComplainantID = reader.GetInt32(6);
                    com.ComplainantName = reader.GetString(7);
                    com.ComplainantUserName = reader.GetString(8);
                    com.AnswerStatusID = reader.GetInt32(9);
                    com.AnswerStatusName = reader.GetString(10);
                    com.ComplainantDateStr = reader.GetDateTime(11).ToShortDateString();
                    com.ComplainantTimeStr = reader.GetDateTime(11).ToShortTimeString();
                    list.Add(com);
                }

                return list;

            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Complaints> ListMemberComplaintsNotAccepted()
        {
            List<Complaints> list = new List<Complaints>();
            try
            {
                cmd.CommandText = "SELECT com.ID,com.Explanation,com.ComplaintReason_ID,cr.Reason,com.Member_ID,mem.UserName,com.Complainant_ID,cm.Name,cm.UserName,com.AnswerStatus_ID,ans.Name,com.ComplaintDate FROM Complaints AS com JOIN ComplaintReasons AS cr ON com.ComplaintReason_ID=cr.ID JOIN Members AS mem ON com.Member_ID=mem.ID JOIN Members AS cm ON com.Complainant_ID=cm.ID JOIN AnswerStatus AS ans ON com.AnswerStatus_ID=ans.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Complaints com = new Complaints();
                    com.ID = reader.GetInt32(0);
                    com.Explanation = reader.GetString(1);
                    com.ComplaintReasonID = reader.GetInt32(2);
                    com.ComplaintReason = reader.GetString(3);
                    com.MemberID = reader.GetInt32(4);
                    com.MemberUserName = reader.GetString(5);
                    com.ComplainantID = reader.GetInt32(6);
                    com.ComplainantName = reader.GetString(7);
                    com.ComplainantUserName = reader.GetString(8);
                    com.AnswerStatusID = reader.GetInt32(9);
                    com.AnswerStatusName = reader.GetString(10);
                    com.ComplainantDateStr = reader.GetDateTime(11).ToShortDateString();
                    com.ComplainantTimeStr = reader.GetDateTime(11).ToShortTimeString();
                    list.Add(com);
                }

                return list;

            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Complaints> ListMemberComplaintsNotAccepted(int ansid)
        {
            List<Complaints> list = new List<Complaints>();
            try
            {
                cmd.CommandText = "SELECT com.ID,com.Explanation,com.ComplaintReason_ID,cr.Reason,com.Member_ID,mem.UserName,com.Complainant_ID,cm.Name,cm.UserName,com.AnswerStatus_ID,ans.Name,com.ComplaintDate FROM Complaints AS com JOIN ComplaintReasons AS cr ON com.ComplaintReason_ID=cr.ID JOIN Members AS mem ON com.Member_ID=mem.ID JOIN Members AS cm ON com.Complainant_ID=cm.ID JOIN AnswerStatus AS ans ON com.AnswerStatus_ID=ans.ID WHERE com.AnswerStatus_ID=@ansid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ansid", ansid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Complaints com = new Complaints();
                    com.ID = reader.GetInt32(0);
                    com.Explanation = reader.GetString(1);
                    com.ComplaintReasonID = reader.GetInt32(2);
                    com.ComplaintReason = reader.GetString(3);
                    com.MemberID = reader.GetInt32(4);
                    com.MemberUserName = reader.GetString(5);
                    com.ComplainantID = reader.GetInt32(6);
                    com.ComplainantName = reader.GetString(7);
                    com.ComplainantUserName = reader.GetString(8);
                    com.AnswerStatusID = reader.GetInt32(9);
                    com.AnswerStatusName = reader.GetString(10);
                    com.ComplainantDateStr = reader.GetDateTime(11).ToShortDateString();
                    com.ComplainantTimeStr = reader.GetDateTime(11).ToShortTimeString();
                    list.Add(com);
                }

                return list;

            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public Complaints GetCommendComplaintNotAccepted(int comid)
        {
            try
            {
                cmd.CommandText = "SELECT com.ID,com.Explanation,com.ComplaintReason_ID,cr.Reason,com.Comment_ID,c.Contents,com.Complainant_ID,cm.Name,cm.UserName,com.AnswerStatus_ID,ans.Name,com.ComplaintDate FROM Complaints AS com JOIN ComplaintReasons AS cr ON com.ComplaintReason_ID=cr.ID JOIN Comments AS c ON com.Comment_ID=c.ID JOIN Members AS cm ON com.Complainant_ID=cm.ID JOIN AnswerStatus AS ans ON com.AnswerStatus_ID=ans.ID WHERE com.AnswerStatus_ID=1 AND com.ID=@comid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@comid", comid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Complaints com = new Complaints();
                while (reader.Read())
                {
                    com.ID = reader.GetInt32(0);
                    com.Explanation = reader.GetString(1);
                    com.ComplaintReasonID = reader.GetInt32(2);
                    com.ComplaintReason = reader.GetString(3);
                    com.CommentID = reader.GetInt32(4);
                    com.CommentContent = reader.GetString(5);
                    com.ComplainantID = reader.GetInt32(6);
                    com.ComplainantName = reader.GetString(7);
                    com.ComplainantUserName = reader.GetString(8);
                    com.AnswerStatusID = reader.GetInt32(9);
                    com.AnswerStatusName = reader.GetString(10);
                    com.ComplainantDate = reader.GetDateTime(11);
                    com.ComplainantDateStr = reader.GetDateTime(11).ToShortDateString();
                    com.ComplainantTimeStr = reader.GetDateTime(11).ToShortTimeString();
                }
                return com;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public Complaints GetArtworkComplaintNotAccepted(int comid)
        {
            try
            {
                cmd.CommandText = "SELECT com.ID,com.Explanation,com.ComplaintReason_ID,cr.Reason,com.Artwork_ID,aw.Name,com.Complainant_ID,cm.Name,cm.UserName,com.AnswerStatus_ID,ans.Name,com.ComplaintDate FROM Complaints AS com JOIN ComplaintReasons AS cr ON com.ComplaintReason_ID=cr.ID JOIN Artworks AS aw ON com.Artwork_ID=aw.ID JOIN Members AS cm ON com.Complainant_ID=cm.ID JOIN AnswerStatus AS ans ON com.AnswerStatus_ID=ans.ID WHERE com.AnswerStatus_ID=1 AND com.ID=@comid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@comid", comid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Complaints com = new Complaints();
                while (reader.Read())
                {
                    com.ID = reader.GetInt32(0);
                    com.Explanation = reader.GetString(1);
                    com.ComplaintReasonID = reader.GetInt32(2);
                    com.ComplaintReason = reader.GetString(3);
                    com.ArtworkID = reader.GetInt32(4);
                    com.ArtworkName = reader.GetString(5);
                    com.ComplainantID = reader.GetInt32(6);
                    com.ComplainantName = reader.GetString(7);
                    com.ComplainantUserName = reader.GetString(8);
                    com.AnswerStatusID = reader.GetInt32(9);
                    com.AnswerStatusName = reader.GetString(10);
                    com.ComplainantDate = reader.GetDateTime(11);
                    com.ComplainantDateStr = reader.GetDateTime(11).ToShortDateString();
                    com.ComplainantTimeStr = reader.GetDateTime(11).ToShortTimeString();
                }
                return com;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public bool UpdateComplaintsForAccepted(Complaints com)
        {
            try
            {
                cmd.CommandText = "UPDATE Complaints SET Approver_ID=@appID, ApprovedDate=@appDate, AnswerStatus_ID=@ansid WHERE ID=@comid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@appID", com.ApproverID);
                cmd.Parameters.AddWithValue("@appDate", com.ApprovedDate);
                cmd.Parameters.AddWithValue("@ansid", com.AnswerStatusID);
                cmd.Parameters.AddWithValue("@comid", com.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }

        #endregion
        #region Artworks Transactions

        public List<Artworks> ListArtworks(int ansid)
        {
            List<Artworks> artworks = new List<Artworks>();
            try
            {
                cmd.CommandText = "SELECT AW.ID,AW.Name,AW.Info,AW.ArtCategory_ID,AC.Name,AW.Uploader_ID,UP.Name,UP.UserName,AW.Approver_ID,AP.Name,AP.UserName,AW.AgeRange_ID,AR.AgeRange,AW.LikeCounts,AW.DislikeCounts,AW.ViewsCounts,AW.UploadDateTime,AW.ApprovedDateTime,AW.AnswerStatus_ID,Ans.Name FROM Artworks AS AW JOIN ArtCategories AS AC ON AW.ArtCategory_ID=AC.ID JOIN Members AS UP ON AW.Uploader_ID=UP.ID JOIN Members AS AP ON AW.Approver_ID=AP.ID JOIN AgeRanges AS AR ON AW.AgeRange_ID=AR.ID JOIN AnswerStatus AS Ans ON AW.AnswerStatus_ID=Ans.ID WHERE AW.AnswerStatus_ID=@ansid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ansid", ansid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artworks a = new Artworks();
                    a.ID = reader.GetInt32(0);
                    a.Name = reader.GetString(1);
                    a.Info = reader.GetString(2);
                    a.ArtCategoryID = reader.GetInt32(3);
                    a.ArtCategoryName = reader.GetString(4);
                    a.UploaderID = reader.GetInt32(5);
                    a.UploaderName = reader.GetString(6);
                    a.UploaderUserName = reader.GetString(7);
                    a.ApproverID = reader.GetInt32(8);
                    a.ApproverName = reader.GetString(9);
                    a.ApproverUserName = reader.GetString(10);
                    a.AgeRangeID = reader.GetInt32(11);
                    a.AgeRangeStr = reader.GetString(12);
                    a.LikeCounts = !reader.IsDBNull(13) ? reader.GetInt32(13) : 0;
                    a.DislikeCounts = !reader.IsDBNull(14) ? reader.GetInt32(14) : 0;
                    a.ViewsCounts = reader.GetInt32(15);
                    a.UploadDateTime = reader.GetDateTime(16);
                    a.UploadDateStr = reader.GetDateTime(16).ToShortDateString();
                    a.UploadTimeStr = reader.GetDateTime(16).ToShortTimeString();
                    a.ApprovedDateTime = reader.GetDateTime(17);
                    a.ApprovedDateStr = !reader.IsDBNull(17) ? reader.GetDateTime(17).ToShortDateString() : reader.GetDateTime(16).ToShortDateString();
                    a.ApprovedTimeStr = !reader.IsDBNull(17) ? reader.GetDateTime(17).ToShortTimeString() : reader.GetDateTime(16).ToShortTimeString();
                    a.AnswerStatusID = reader.GetInt32(18);
                    a.AnswerStatusName = reader.GetString(19);
                    artworks.Add(a);
                }
                return artworks;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Artworks> ListArtworks()
        {
            List<Artworks> artworks = new List<Artworks>();
            try
            {
                cmd.CommandText = "SELECT AW.ID,AW.Name,AW.Info,AW.ArtCategory_ID,AC.Name,AW.Uploader_ID,UP.Name,UP.UserName,AW.Approver_ID,AP.Name,AP.UserName,AW.AgeRange_ID,AR.AgeRange,AW.LikeCounts,AW.DislikeCounts,AW.ViewsCounts,AW.UploadDateTime,AW.ApprovedDateTime,AW.AnswerStatus_ID,Ans.Name FROM Artworks AS AW JOIN ArtCategories AS AC ON AW.ArtCategory_ID=AC.ID JOIN Members AS UP ON AW.Uploader_ID=UP.ID JOIN Members AS AP ON AW.Approver_ID=AP.ID JOIN AgeRanges AS AR ON AW.AgeRange_ID=AR.ID JOIN AnswerStatus AS Ans ON AW.AnswerStatus_ID=Ans.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artworks a = new Artworks();
                    a.ID = reader.GetInt32(0);
                    a.Name = reader.GetString(1);
                    a.Info = reader.GetString(2);
                    a.ArtCategoryID = reader.GetInt32(3);
                    a.ArtCategoryName = reader.GetString(4);
                    a.UploaderID = reader.GetInt32(5);
                    a.UploaderName = reader.GetString(6);
                    a.UploaderUserName = reader.GetString(7);
                    a.ApproverID = reader.GetInt32(8);
                    a.ApproverName = reader.GetString(9);
                    a.ApproverUserName = reader.GetString(10);
                    a.AgeRangeID = reader.GetInt32(11);
                    a.AgeRangeStr = reader.GetString(12);
                    a.LikeCounts = !reader.IsDBNull(13) ? reader.GetInt32(13) : 0;
                    a.DislikeCounts = !reader.IsDBNull(14) ? reader.GetInt32(14) : 0;
                    a.ViewsCounts = reader.GetInt32(15);
                    a.UploadDateTime = reader.GetDateTime(16);
                    a.UploadDateStr = reader.GetDateTime(16).ToShortDateString();
                    a.UploadTimeStr = reader.GetDateTime(16).ToShortTimeString();
                    a.ApprovedDateTime = reader.GetDateTime(17);
                    a.ApprovedDateStr = !reader.IsDBNull(17) ? reader.GetDateTime(17).ToShortDateString() : reader.GetDateTime(16).ToShortDateString();
                    a.ApprovedTimeStr = !reader.IsDBNull(17) ? reader.GetDateTime(17).ToShortTimeString() : reader.GetDateTime(16).ToShortTimeString();
                    a.AnswerStatusID = reader.GetInt32(18);
                    a.AnswerStatusName = reader.GetString(19);
                    artworks.Add(a);
                }
                return artworks;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Artworks> ListArtworksNotAccepted(int ansid)
        {
            List<Artworks> artworks = new List<Artworks>();
            try
            {
                cmd.CommandText = "SELECT AW.ID,AW.Name,AW.Info,AW.ArtCategory_ID,AC.Name,AW.Uploader_ID,UP.Name,UP.UserName,AW.AgeRange_ID,AR.AgeRange,AW.LikeCounts,AW.DislikeCounts,AW.ViewsCounts,AW.UploadDateTime,AW.AnswerStatus_ID,Ans.Name FROM Artworks AS AW JOIN ArtCategories AS AC ON AW.ArtCategory_ID=AC.ID JOIN Members AS UP ON AW.Uploader_ID=UP.ID JOIN AgeRanges AS AR ON AW.AgeRange_ID=AR.ID JOIN AnswerStatus AS Ans ON AW.AnswerStatus_ID=Ans.ID WHERE AW.AnswerStatus_ID=@ansid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ansid", ansid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artworks a = new Artworks();
                    a.ID = reader.GetInt32(0);
                    a.Name = reader.GetString(1);
                    a.Info = reader.GetString(2);
                    a.ArtCategoryID = reader.GetInt32(3);
                    a.ArtCategoryName = reader.GetString(4);
                    a.UploaderID = reader.GetInt32(5);
                    a.UploaderName = reader.GetString(6);
                    a.UploaderUserName = reader.GetString(7);
                    a.AgeRangeID = reader.GetInt32(8);
                    a.AgeRangeStr = reader.GetString(9);
                    a.LikeCounts = !reader.IsDBNull(10) ? reader.GetInt32(10) : 0;
                    a.DislikeCounts = !reader.IsDBNull(11) ? reader.GetInt32(11) : 0;
                    a.ViewsCounts = reader.GetInt32(12);
                    a.UploadDateTime = reader.GetDateTime(13);
                    a.UploadDateStr = reader.GetDateTime(13).ToShortDateString();
                    a.UploadTimeStr = reader.GetDateTime(13).ToShortTimeString();
                    a.AnswerStatusID = reader.GetInt32(14);
                    a.AnswerStatusName = reader.GetString(15);
                    artworks.Add(a);
                }
                return artworks;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Artworks> ListArtworksNotAccepted()
        {
            List<Artworks> artworks = new List<Artworks>();
            try
            {
                cmd.CommandText = "SELECT AW.ID,AW.Name,AW.Info,AW.ArtCategory_ID,AC.Name,AW.Uploader_ID,UP.Name,UP.UserName,AW.AgeRange_ID,AR.AgeRange,AW.LikeCounts,AW.DislikeCounts,AW.ViewsCounts,AW.UploadDateTime,AW.AnswerStatus_ID,Ans.Name FROM Artworks AS AW JOIN ArtCategories AS AC ON AW.ArtCategory_ID=AC.ID JOIN Members AS UP ON AW.Uploader_ID=UP.ID JOIN AgeRanges AS AR ON AW.AgeRange_ID=AR.ID JOIN AnswerStatus AS Ans ON AW.AnswerStatus_ID=Ans.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artworks a = new Artworks();
                    a.ID = reader.GetInt32(0);
                    a.Name = reader.GetString(1);
                    a.Info = reader.GetString(2);
                    a.ArtCategoryID = reader.GetInt32(3);
                    a.ArtCategoryName = reader.GetString(4);
                    a.UploaderID = reader.GetInt32(5);
                    a.UploaderName = reader.GetString(6);
                    a.UploaderUserName = reader.GetString(7);
                    a.AgeRangeID = reader.GetInt32(8);
                    a.AgeRangeStr = reader.GetString(9);
                    a.LikeCounts = !reader.IsDBNull(10) ? reader.GetInt32(10) : 0;
                    a.DislikeCounts = !reader.IsDBNull(11) ? reader.GetInt32(11) : 0;
                    a.ViewsCounts = reader.GetInt32(12);
                    a.UploadDateTime = reader.GetDateTime(13);
                    a.UploadDateStr = reader.GetDateTime(13).ToShortDateString();
                    a.UploadTimeStr = reader.GetDateTime(13).ToShortTimeString();
                    a.AnswerStatusID = reader.GetInt32(14);
                    a.AnswerStatusName = reader.GetString(15);
                    artworks.Add(a);
                }
                return artworks;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public Artworks GetArtworks(int awid)
        {
            try
            {
                cmd.CommandText = "SELECT AW.ID,AW.Name,AW.Info,AW.ArtCategory_ID,AC.Name,AW.Uploader_ID,UP.Name,UP.UserName,AW.Approver_ID,AP.Name,AP.UserName,AW.AgeRange_ID,AR.AgeRange,AW.LikeCounts,AW.DislikeCounts,AW.ViewsCounts,AW.UploadDateTime,AW.ApprovedDateTime,AW.AnswerStatus_ID,Ans.Name FROM Artworks AS AW JOIN ArtCategories AS AC ON AW.ArtCategory_ID=AC.ID JOIN Members AS UP ON AW.Uploader_ID=UP.ID JOIN Members AS AP ON AW.Approver_ID=AP.ID JOIN AgeRanges AS AR ON AW.AgeRange_ID=AR.ID JOIN AnswerStatus AS Ans ON AW.AnswerStatus_ID=Ans.ID WHERE AW.ID=@awid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@awid", awid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Artworks aw = new Artworks();
                while (reader.Read())
                {
                    aw.ID = reader.GetInt32(0);
                    aw.Name = reader.GetString(1);
                    aw.Info = reader.GetString(2);
                    aw.ArtCategoryID = reader.GetInt32(3);
                    aw.ArtCategoryName = reader.GetString(4);
                    aw.UploaderID = reader.GetInt32(5);
                    aw.UploaderName = reader.GetString(6);
                    aw.UploaderUserName = reader.GetString(7);
                    aw.ApproverID = reader.GetInt32(8);
                    aw.ApproverName = reader.GetString(9);
                    aw.ApproverUserName = reader.GetString(10);
                    aw.AgeRangeID = reader.GetInt32(11);
                    aw.AgeRangeStr = reader.GetString(12);
                    aw.LikeCounts = !reader.IsDBNull(13) ? reader.GetInt32(13) : 0;
                    aw.DislikeCounts = !reader.IsDBNull(14) ? reader.GetInt32(14) : 0;
                    aw.ViewsCounts = reader.GetInt32(15);
                    aw.UploadDateTime = reader.GetDateTime(16);
                    aw.UploadDateStr = reader.GetDateTime(16).ToShortDateString();
                    aw.UploadTimeStr = reader.GetDateTime(16).ToShortTimeString();
                    aw.ApprovedDateTime = !reader.IsDBNull(17) ? reader.GetDateTime(17) : reader.GetDateTime(16);
                    aw.ApprovedDateStr = !reader.IsDBNull(17) ? reader.GetDateTime(17).ToShortDateString() : reader.GetDateTime(16).ToShortDateString();
                    aw.ApprovedTimeStr = !reader.IsDBNull(17) ? reader.GetDateTime(17).ToShortTimeString() : reader.GetDateTime(16).ToShortTimeString();
                    aw.AnswerStatusID = reader.GetInt32(18);
                    aw.AnswerStatusName = reader.GetString(19);
                }
                return aw;

            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public Artworks GetArtworksNotAccepted(int awid)
        {
            try
            {
                cmd.CommandText = "SELECT AW.ID,AW.Name,AW.Info,AW.ArtCategory_ID,AC.Name,AW.Uploader_ID,UP.Name,UP.UserName,AW.AgeRange_ID,AR.AgeRange,AW.LikeCounts,AW.DislikeCounts,AW.ViewsCounts,AW.UploadDateTime,AW.AnswerStatus_ID,Ans.Name FROM Artworks AS AW JOIN ArtCategories AS AC ON AW.ArtCategory_ID=AC.ID JOIN Members AS UP ON AW.Uploader_ID=UP.ID JOIN AgeRanges AS AR ON AW.AgeRange_ID=AR.ID JOIN AnswerStatus AS Ans ON AW.AnswerStatus_ID=Ans.ID WHERE AW.ID=@awid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@awid", awid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Artworks aw = new Artworks();
                while (reader.Read())
                {
                    aw.ID = reader.GetInt32(0);
                    aw.Name = reader.GetString(1);
                    aw.Info = reader.GetString(2);
                    aw.ArtCategoryID = reader.GetInt32(3);
                    aw.ArtCategoryName = reader.GetString(4);
                    aw.UploaderID = reader.GetInt32(5);
                    aw.UploaderName = reader.GetString(6);
                    aw.UploaderUserName = reader.GetString(7);
                    aw.AgeRangeID = reader.GetInt32(8);
                    aw.AgeRangeStr = reader.GetString(9);
                    aw.LikeCounts = !reader.IsDBNull(10) ? reader.GetInt32(10) : 0;
                    aw.DislikeCounts = !reader.IsDBNull(11) ? reader.GetInt32(11) : 0;
                    aw.ViewsCounts = reader.GetInt32(12);
                    aw.UploadDateTime = reader.GetDateTime(13);
                    aw.UploadDateStr = reader.GetDateTime(13).ToShortDateString();
                    aw.UploadTimeStr = reader.GetDateTime(13).ToShortTimeString();
                    aw.AnswerStatusID = reader.GetInt32(14);
                    aw.AnswerStatusName = reader.GetString(15);
                }
                return aw;

            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public bool UpdateArtwork(Artworks aw)
        {
            try
            {
                cmd.CommandText = "UPDATE Artworks SET Name=@name, Info=@info, ArtCategory_ID=@acid, Uploader_ID=@upid, Approver_ID=@appid, AgeRange_ID=@arid, LikeCounts=@likecounts, DislikeCounts=@dislikecounts, ViewsCounts=@viewscounts, UploadDateTime=@uploaddatetime, ApprovedDateTime=@approveddatetime, AnswerStatus_ID=@ansid WHERE ID=@awid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", aw.Name);
                cmd.Parameters.AddWithValue("@info", aw.Info);
                cmd.Parameters.AddWithValue("@acid", aw.ArtCategoryID);
                cmd.Parameters.AddWithValue("@upid", aw.UploaderID);
                cmd.Parameters.AddWithValue("@appid", aw.ApproverID);
                cmd.Parameters.AddWithValue("@arid", aw.AgeRangeID);
                cmd.Parameters.AddWithValue("@likecounts", aw.LikeCounts);
                cmd.Parameters.AddWithValue("@dislikecounts", aw.DislikeCounts);
                cmd.Parameters.AddWithValue("@viewscounts", aw.ViewsCounts);
                cmd.Parameters.AddWithValue("@uploaddatetime", aw.UploadDateTime);
                cmd.Parameters.AddWithValue("@approveddatetime", aw.ApprovedDateTime);
                cmd.Parameters.AddWithValue("@ansid", aw.AnswerStatusID);
                cmd.Parameters.AddWithValue("@awid", aw.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public bool AddArtwork(Artworks aw)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Artworks(Name,Info,ArtCategory_ID,Uploader_ID,Approver_ID,AgeRange_ID,LikeCounts,DislikeCounts,ViewsCounts,UploadDateTime,ApprovedDateTime,AnswerStatus_ID) VALUES(@name,@info,@acid,@upid,@appid,@arid,@likecounts,@dislikecounts,@viewscounts,@uploaddatetime,@approveddatetime,@ansid)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", aw.Name);
                cmd.Parameters.AddWithValue("@info", aw.Info);
                cmd.Parameters.AddWithValue("@acid", aw.ArtCategoryID);
                cmd.Parameters.AddWithValue("@upid", aw.UploaderID);
                cmd.Parameters.AddWithValue("@appid", aw.ApproverID);
                cmd.Parameters.AddWithValue("@arid", aw.AgeRangeID);
                cmd.Parameters.AddWithValue("@likecounts", aw.LikeCounts);
                cmd.Parameters.AddWithValue("@dislikecounts", aw.DislikeCounts);
                cmd.Parameters.AddWithValue("@viewscounts", aw.ViewsCounts);
                cmd.Parameters.AddWithValue("@uploaddatetime", aw.UploadDateTime);
                cmd.Parameters.AddWithValue("@approveddatetime", aw.ApprovedDateTime);
                cmd.Parameters.AddWithValue("@ansid", aw.AnswerStatusID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }

        #endregion
        #region Requests Transactions
        public List<Requests> ListRequestsUnread(int rsid)
        {
            List<Requests> list = new List<Requests>();
            try
            {
                cmd.CommandText = "SELECT R.ID,R.Summary,R.RequestContents,R.Member_ID,M.Name,M.UserName,R.RequestDate,R.ReadStatus FROM Requests AS R JOIN Members AS M ON R.Member_ID=M.ID WHERE R.ReadStatus=@rsid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@rsid", rsid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Requests r = new Requests();
                    r.ID = reader.GetInt32(0);
                    r.Summary = reader.GetString(1);
                    r.RequestContents = reader.GetString(2);
                    r.MemberID = reader.GetInt32(3);
                    r.MemberName = reader.GetString(4);
                    r.MemberUserName = reader.GetString(5);
                    r.RequestDateStr = reader.GetDateTime(6).ToShortDateString();
                    r.RequestTimeStr = reader.GetDateTime(6).ToShortTimeString();
                    r.ReadStatusStr = reader.GetBoolean(7) ? "<label style='color:green'>Okundu</label>" : "<label style='color:gray'>Okunacak</label>";
                    list.Add(r);
                }
                return list;

            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }

        public List<Requests> ListRequestsUnread()
        {
            List<Requests> list = new List<Requests>();
            try
            {
                cmd.CommandText = "SELECT R.ID,R.Summary,R.RequestContents,R.Member_ID,M.Name,M.UserName,R.RequestDate,R.ReadStatus FROM Requests AS R JOIN Members AS M ON R.Member_ID=M.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Requests r = new Requests();
                    r.ID = reader.GetInt32(0);
                    r.Summary = reader.GetString(1);
                    r.RequestContents = reader.GetString(2);
                    r.MemberID = reader.GetInt32(3);
                    r.MemberName = reader.GetString(4);
                    r.MemberUserName = reader.GetString(5);
                    r.RequestDateStr = reader.GetDateTime(6).ToShortDateString();
                    r.RequestTimeStr = reader.GetDateTime(6).ToShortTimeString();
                    r.ReadStatusStr = reader.GetBoolean(7) ? "<label style='color:green'>Okundu</label>" : "<label style='color:gray'>Okunacak</label>";
                    list.Add(r);
                }
                return list;

            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Requests> ListRequestsRead()
        {
            List<Requests> list = new List<Requests>();
            try
            {
                cmd.CommandText = "SELECT R.ID,R.Summary,R.RequestContents,R.Member_ID,M.UserName,R.RequestDate,R.Reader_ID,RM.UserName,R.Readingdate,R.ReadStatus FROM Requests AS R JOIN Members AS M ON R.Member_ID=M.ID JOIN Members AS RM ON R.Reader_ID=RM.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Requests r = new Requests();
                    r.ID = reader.GetInt32(0);
                    r.Summary = reader.GetString(1);
                    r.RequestContents = reader.GetString(2);
                    r.MemberID = reader.GetInt32(3);
                    r.MemberUserName = reader.GetString(4);
                    r.RequestDateStr = reader.GetDateTime(5).ToShortDateString();
                    r.RequestTimeStr = reader.GetDateTime(5).ToShortTimeString();
                    r.ReaderID = !reader.IsDBNull(6) ? reader.GetInt32(6) : 0;
                    r.ReaderUserName = !reader.IsDBNull(7) ? reader.GetString(7) : "";
                    r.ReadingDateStr = !reader.IsDBNull(8) ? reader.GetDateTime(8).ToShortDateString() : reader.GetDateTime(5).ToShortDateString();
                    r.ReadingTimeStr = !reader.IsDBNull(8) ? reader.GetDateTime(8).ToShortTimeString() : reader.GetDateTime(5).ToShortTimeString();
                    r.ReadStatusStr = reader.GetBoolean(9) ? "<label style='color:green'>Okundu</label>" : "<label style='color:gray'>Okunacak</label>";
                }
                return list;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<Requests> ListRequestsRead(int rsid)
        {
            List<Requests> list = new List<Requests>();
            try
            {
                cmd.CommandText = "SELECT R.ID,R.Summary,R.RequestContents,R.Member_ID,M.UserName,R.RequestDate,R.Reader_ID,RM.UserName,R.Readingdate,R.ReadStatus FROM Requests AS R JOIN Members AS M ON R.Member_ID=M.ID JOIN Members AS RM ON R.Reader_ID=RM.ID WHERE R.ReadStatus=@rsid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@rsid", rsid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Requests r = new Requests();
                    r.ID = reader.GetInt32(0);
                    r.Summary = reader.GetString(1);
                    r.RequestContents = reader.GetString(2);
                    r.MemberID = reader.GetInt32(3);
                    r.MemberUserName = reader.GetString(4);
                    r.RequestDateStr = reader.GetDateTime(5).ToShortDateString();
                    r.RequestTimeStr = reader.GetDateTime(5).ToShortTimeString();
                    r.ReaderID = !reader.IsDBNull(6) ? reader.GetInt32(6) : 0;
                    r.ReaderUserName = !reader.IsDBNull(7) ? reader.GetString(7) : "";
                    r.ReadingDateStr = !reader.IsDBNull(8) ? reader.GetDateTime(8).ToShortDateString() : reader.GetDateTime(5).ToShortDateString();
                    r.ReadingTimeStr = !reader.IsDBNull(8) ? reader.GetDateTime(8).ToShortTimeString() : reader.GetDateTime(5).ToShortTimeString();
                    r.ReadStatusStr = reader.GetBoolean(9) ? "<label style='color:green'>Okundu</label>" : "<label style='color:gray'>Okunacak</label>";
                    list.Add(r);
                }
                return list;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        #endregion
        #region ComplaintReason Transactions
        public List<ComplaintReasons> ListComplaintReason()
        {
            List<ComplaintReasons> list = new List<ComplaintReasons>();
            try
            {
                cmd.CommandText = "SELECT ID,Reason FROM ComplaintReasons";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ComplaintReasons cr = new ComplaintReasons();
                    cr.ID = reader.GetInt32(0);
                    cr.Reason = reader.GetString(1);
                    list.Add(cr);
                }
                return list;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public bool addComplaintReason(ComplaintReasons cr)
        {
            try
            {
                cmd.CommandText = "INSERT INTO ComplaintReasons(Reason) VALUES (@name)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", cr.Reason);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public bool deleteComplaintReason(int crid)
        {
            try
            {
                cmd.CommandText = "DELETE FROM ComplaintReasons WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", crid);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public ComplaintReasons GetComplaintReasons(int crid)
        {
            ComplaintReasons cr = new ComplaintReasons();
            try
            {
                cmd.CommandText = "SELECT ID,Reason FROM ComplaintReasons WHERE ID=@crid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@crid", crid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cr.ID = reader.GetInt32(0);
                    cr.Reason = reader.GetString(1);
                }
                return cr;

            }
            catch
            {

                return null;
            }
        }
        public bool editComplaintReason(ComplaintReasons cr)
        {
            try
            {
                cmd.CommandText = "UPDATE ComplaintReasons SET Reason = @Reason WHERE ID=@crid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Reason", cr.Reason);
                cmd.Parameters.AddWithValue("@crid", cr.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        #endregion
        #region SecurityQestions Transactions
        public List<SecurityQestions> ListSecurityQestions()
        {
            List<SecurityQestions> list = new List<SecurityQestions>();
            try
            {
                cmd.CommandText = "SELECT ID,Qestions FROM SecurityQestions";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SecurityQestions sq = new SecurityQestions();
                    sq.ID = reader.GetInt32(0);
                    sq.Questions = reader.GetString(1);
                    list.Add(sq);
                }

                return list;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public bool AddSecurityQestions(SecurityQestions sq)
        {
            try
            {
                cmd.CommandText = "INSERT INTO SecurityQestions(Qestions) VALUES(@question)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@question", sq.Questions);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public SecurityQestions GetSecurityQestion(int sqid)
        {
            try
            {
                cmd.CommandText = "SELECT ID,Qestions FROM SecurityQestions WHERE ID=@sqid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sqid", sqid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                SecurityQestions sq = new SecurityQestions();
                while (reader.Read())
                {
                    sq.ID = reader.GetInt32(0);
                    sq.Questions = reader.GetString(1);
                }
                return sq;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public bool DeleteSecurityQestion(int sqid)
        {
            try
            {
                cmd.CommandText = "DELETE FROM SecurityQestions WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", sqid);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public bool EditSecurityQestion(SecurityQestions sq)
        {
            try
            {
                cmd.CommandText = "UPDATE SecurityQestions SET Qestions = @qestions WHERE ID=@sqid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@qestions", sq.Questions);
                cmd.Parameters.AddWithValue("@sqid", sq.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }


        #endregion
        #region AgeRanges Transactions
        public List<AgeRanges> ListAgeRanges()
        {
            List<AgeRanges> list = new List<AgeRanges>();
            try
            {
                cmd.CommandText = "SELECT * FROM AgeRanges";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AgeRanges ar = new AgeRanges();
                    ar.ID = reader.GetInt32(0);
                    ar.AgeRange = reader.GetString(1);
                    list.Add(ar);
                }
                return list;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public bool AddAgeRange(AgeRanges ar)
        {
            try
            {
                cmd.CommandText = "INSERT INTO AgeRanges(AgeRange) VALUES(@agerange)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@agerange", ar.AgeRange);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public AgeRanges GetAgeRange(int arid)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM AgeRanges WHERE ID=@arid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@arid", arid);
                con.Open();
                AgeRanges ar = new AgeRanges();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ar.ID = reader.GetInt32(0);
                    ar.AgeRange = reader.GetString(1);
                }
                return ar;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public bool DeleteAgeRange(int arid)
        {
            try
            {
                cmd.CommandText = "DELETE FROM AgeRanges WHERE ID=@arid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@arid", arid);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        public bool EditAgeRange(AgeRanges ar)
        {
            try
            {
                cmd.CommandText = "UPDATE AgeRanges SET AgeRange = @agerange WHERE ID=@arid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@arid", ar.ID);
                cmd.Parameters.AddWithValue("@agerange", ar.AgeRange);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
        #endregion
        #region ArtworkImages Transactions
        public ArtworkImages GetCoverImage()
        {
            try
            {
                cmd.CommandText = "SELECT ID,Artwork_ID,AltText,ImagePath,IsCover FROM ArtworkImages AS awi WHERE IsCover=1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ArtworkImages awi = new ArtworkImages();
                while (reader.Read())
                {
                    awi.ID = reader.GetInt32(0);
                    awi.ArtworkID = reader.GetInt32(1);
                    awi.AltText = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                    awi.ImagePath = reader.GetString(3);
                    awi.IsCover = reader.GetBoolean(4);
                }
                return awi;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }

        }
        public ArtworkImages GetCoverImageWithArtworkID(int awid)
        {
            try
            {
                cmd.CommandText = "SELECT ID,Artwork_ID,AltText,ImagePath,IsCover FROM ArtworkImages AS awi WHERE IsCover=1 AND Artwork_ID=@awid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@awid", awid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ArtworkImages awi = new ArtworkImages();
                while (reader.Read())
                {
                    awi.ID = reader.GetInt32(0);
                    awi.ArtworkID = reader.GetInt32(1);
                    awi.AltText = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                    awi.ImagePath = reader.GetString(3);
                    awi.IsCover = reader.GetBoolean(4);
                }
                return awi;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }

        }
        public List<ArtworkImages> ListArtworkImages()
        {
            List<ArtworkImages> awimages = new List<ArtworkImages>();
            try
            {
                cmd.CommandText = "SELECT ID,Artwork_ID,AltText,ImagePath,IsCover FROM ArtworkImages";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ArtworkImages awi = new ArtworkImages();
                    awi.ID = reader.GetInt32(0);
                    awi.ArtworkID = reader.GetInt32(1);
                    awi.AltText = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                    awi.ImagePath = reader.GetString(3);
                    awi.IsCover = reader.GetBoolean(4);
                    awimages.Add(awi);
                }
                return awimages;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public List<ArtworkImages> ListArtworkImagesWithArtworkID(int awid)
        {
            List<ArtworkImages> awimages = new List<ArtworkImages>();
            try
            {
                cmd.CommandText = "SELECT ID,Artwork_ID,AltText,ImagePath,IsCover FROM ArtworkImages WHERE Artwork_ID=@awid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@awid", awid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ArtworkImages awi = new ArtworkImages();
                    awi.ID = reader.GetInt32(0);
                    awi.ArtworkID = reader.GetInt32(1);
                    awi.AltText = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                    awi.ImagePath = reader.GetString(3);
                    awi.IsCover = reader.GetBoolean(4);
                    awimages.Add(awi);
                }
                return awimages;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public ArtworkImages GetArtworkImageByID(int awimgid)
        {
            try
            {
                cmd.CommandText = "SELECT ID,Artwork_ID,AltText,ImagePath,IsCover FROM ArtworkImages WHERE ID=@awimgid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@awimgid", awimgid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ArtworkImages awi = new ArtworkImages();
                while (reader.Read())
                {
                    awi.ID = reader.GetInt32(0);
                    awi.ArtworkID = reader.GetInt32(1);
                    awi.AltText = reader.GetString(2);
                    awi.ImagePath = reader.GetString(3);
                    awi.IsCover = reader.GetBoolean(4);
                }
                return awi;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        #endregion
        #region Helper Transactions
        public bool dataControl(string table, string column, string data)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM " + table + " WHERE " + column + " = @name";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", data);
                con.Open();
                int countdata = Convert.ToInt32(cmd.ExecuteScalar());
                if (countdata == 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Close();
            }
        }
        public Members AdminLogin(string mail, string password)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Members WHERE Email=@mail AND UserPassword=@password";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    cmd.CommandText = "SELECT mem.ID,mem.Name,mem.Surname,mem.MembershipStatus_ID,ms.Name,mem.ProfilPhoto,mem.Info,mem.Email,mem.Birthday,mem.UserName,mem.UserPassword,mem.SecurityQestions_ID,sq.Qestions,mem.SecurityAnswer,mem.VisitorCounts,mem.RegistrationDate,mem.UserStatus FROM Members AS mem JOIN MembershipStatus AS ms ON mem.MembershipStatus_ID=ms.ID JOIN SecurityQestions AS sq ON mem.SecurityQestions_ID=sq.ID WHERE Email=@mail AND UserPassword=@password";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Members mem = new Members();
                    while (reader.Read())
                    {
                        mem.ID = reader.GetInt32(0);
                        mem.Name = reader.GetString(1);
                        mem.Surname = reader.GetString(2);
                        mem.MembershipStatusID = reader.GetInt32(3);
                        mem.MembershipStatusName = reader.GetString(4);
                        mem.ProfilPhoto = !reader.IsDBNull(5) ? reader.GetString(5) : "none.png";
                        mem.Info = reader.GetString(6);
                        mem.Email = reader.GetString(7);
                        mem.BirthdayStr = reader.GetDateTime(8).ToShortDateString();
                        mem.UserName = reader.GetString(9);
                        mem.UserPassword = reader.GetString(10);
                        mem.SecurityQestionsID = reader.GetInt32(11);
                        mem.SecurityQestionsQestion = reader.GetString(12);
                        mem.SecurityAnswer = reader.GetString(13);
                        mem.VisitorCounts = reader.GetInt32(14);
                        mem.RegistrationDate = reader.GetDateTime(15);
                        mem.RegistrationDateStr = reader.GetDateTime(15).ToShortDateString();
                        mem.RegistrationTimeStr = reader.GetDateTime(15).ToShortTimeString();
                        mem.UserStatus = reader.GetBoolean(16);
                    }
                    return mem;

                }
                else
                {
                    return null;
                }

            }
            finally { con.Close(); }
        }
        #endregion
    }
}
