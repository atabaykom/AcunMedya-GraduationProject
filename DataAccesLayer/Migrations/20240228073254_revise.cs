using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class revise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentAnswers_Contents_CONTENTID",
                table: "ContentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentInteractions_Contents_CONTENTID",
                table: "ContentInteractions");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentQuestions_Contents_CONTENTID",
                table: "ContentQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_ContentCategories_CATEGORYID",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentTagMaps_Contents_CONTENTID",
                table: "ContentTagMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentTagMaps_Tags_TAGID",
                table: "ContentTagMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_FirmDocs_Contents_CONTENTID",
                table: "FirmDocs");

            migrationBuilder.RenameColumn(
                name: "TOADRESS",
                table: "Notifications",
                newName: "ToAdress");

            migrationBuilder.RenameColumn(
                name: "SUBJECT",
                table: "Notifications",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "Notifications",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "RETRYCOUNT",
                table: "Notifications",
                newName: "RetryCount");

            migrationBuilder.RenameColumn(
                name: "ISDELIVERED",
                table: "Notifications",
                newName: "IsDelivered");

            migrationBuilder.RenameColumn(
                name: "BODY",
                table: "Notifications",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "EMAILQUEUEID",
                table: "Notifications",
                newName: "EmailQueueID");

            migrationBuilder.RenameColumn(
                name: "LASTRERYDATE",
                table: "Notifications",
                newName: "LastRetryDate");

            migrationBuilder.RenameColumn(
                name: "SENDERNAME",
                table: "Messages",
                newName: "SenderName");

            migrationBuilder.RenameColumn(
                name: "SENDERMAIL",
                table: "Messages",
                newName: "SenderMail");

            migrationBuilder.RenameColumn(
                name: "RECEIVERNAME",
                table: "Messages",
                newName: "ReceiverNAme");

            migrationBuilder.RenameColumn(
                name: "RECEIVERMAIL",
                table: "Messages",
                newName: "ReceiverMail");

            migrationBuilder.RenameColumn(
                name: "DATE",
                table: "Messages",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CONTENT",
                table: "Messages",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "MESSAGEID",
                table: "Messages",
                newName: "MessageID");

            migrationBuilder.RenameColumn(
                name: "IMGDATA",
                table: "FirmDocs",
                newName: "IMGData");

            migrationBuilder.RenameColumn(
                name: "CONTENTID",
                table: "FirmDocs",
                newName: "ContentID");

            migrationBuilder.RenameColumn(
                name: "IMGID",
                table: "FirmDocs",
                newName: "ImgID");

            migrationBuilder.RenameIndex(
                name: "IX_FirmDocs_CONTENTID",
                table: "FirmDocs",
                newName: "IX_FirmDocs_ContentID");

            migrationBuilder.RenameColumn(
                name: "TAGID",
                table: "ContentTagMaps",
                newName: "TagID");

            migrationBuilder.RenameColumn(
                name: "CONTENTID",
                table: "ContentTagMaps",
                newName: "ContentID");

            migrationBuilder.RenameColumn(
                name: "MAPID",
                table: "ContentTagMaps",
                newName: "MapId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentTagMaps_TAGID",
                table: "ContentTagMaps",
                newName: "IX_ContentTagMaps_TagID");

            migrationBuilder.RenameIndex(
                name: "IX_ContentTagMaps_CONTENTID",
                table: "ContentTagMaps",
                newName: "IX_ContentTagMaps_ContentID");

            migrationBuilder.RenameColumn(
                name: "TOWN",
                table: "Contents",
                newName: "Town");

            migrationBuilder.RenameColumn(
                name: "TITLE",
                table: "Contents",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "PRICE",
                table: "Contents",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "NUMBEROFROOMS",
                table: "Contents",
                newName: "NumberOfRooms");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "Contents",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "Contents",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CREATEDDATE",
                table: "Contents",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "COUNTRY",
                table: "Contents",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "CONTENTTYPE",
                table: "Contents",
                newName: "ContentType");

            migrationBuilder.RenameColumn(
                name: "CONTENTFROM",
                table: "Contents",
                newName: "ContentFrom");

            migrationBuilder.RenameColumn(
                name: "CITY",
                table: "Contents",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "CATEGORYID",
                table: "Contents",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "ADRESS",
                table: "Contents",
                newName: "Adress");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_CATEGORYID",
                table: "Contents",
                newName: "IX_Contents_CategoryID");

            migrationBuilder.RenameColumn(
                name: "USERID",
                table: "ContentQuestions",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "ContentQuestions",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CONTENTID",
                table: "ContentQuestions",
                newName: "ContentID");

            migrationBuilder.RenameColumn(
                name: "QUESTIONID",
                table: "ContentQuestions",
                newName: "QuestionID");

            migrationBuilder.RenameIndex(
                name: "IX_ContentQuestions_CONTENTID",
                table: "ContentQuestions",
                newName: "IX_ContentQuestions_ContentID");

            migrationBuilder.RenameColumn(
                name: "VIEWCOUNT",
                table: "ContentInteractions",
                newName: "ViewCount");

            migrationBuilder.RenameColumn(
                name: "FAVORITECOUNT",
                table: "ContentInteractions",
                newName: "FavoriteCount");

            migrationBuilder.RenameColumn(
                name: "CONTENTID",
                table: "ContentInteractions",
                newName: "ContentID");

            migrationBuilder.RenameColumn(
                name: "INTERACTIONID",
                table: "ContentInteractions",
                newName: "InteractionID");

            migrationBuilder.RenameIndex(
                name: "IX_ContentInteractions_CONTENTID",
                table: "ContentInteractions",
                newName: "IX_ContentInteractions_ContentID");

            migrationBuilder.RenameColumn(
                name: "USERID",
                table: "ContentAnswers",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "ContentAnswers",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CONTENTID",
                table: "ContentAnswers",
                newName: "ContentID");

            migrationBuilder.RenameColumn(
                name: "ANSWERID",
                table: "ContentAnswers",
                newName: "AnswerID");

            migrationBuilder.RenameIndex(
                name: "IX_ContentAnswers_CONTENTID",
                table: "ContentAnswers",
                newName: "IX_ContentAnswers_ContentID");

            migrationBuilder.RenameColumn(
                name: "SURNAME",
                table: "AspNetUsers",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "AspNetUsers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ISACTIVE",
                table: "AspNetUsers",
                newName: "IsActive");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentAnswers_Contents_ContentID",
                table: "ContentAnswers",
                column: "ContentID",
                principalTable: "Contents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentInteractions_Contents_ContentID",
                table: "ContentInteractions",
                column: "ContentID",
                principalTable: "Contents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentQuestions_Contents_ContentID",
                table: "ContentQuestions",
                column: "ContentID",
                principalTable: "Contents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_ContentCategories_CategoryID",
                table: "Contents",
                column: "CategoryID",
                principalTable: "ContentCategories",
                principalColumn: "CATEGORYID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentTagMaps_Contents_ContentID",
                table: "ContentTagMaps",
                column: "ContentID",
                principalTable: "Contents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentTagMaps_Tags_TagID",
                table: "ContentTagMaps",
                column: "TagID",
                principalTable: "Tags",
                principalColumn: "TAGID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FirmDocs_Contents_ContentID",
                table: "FirmDocs",
                column: "ContentID",
                principalTable: "Contents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentAnswers_Contents_ContentID",
                table: "ContentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentInteractions_Contents_ContentID",
                table: "ContentInteractions");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentQuestions_Contents_ContentID",
                table: "ContentQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_ContentCategories_CategoryID",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentTagMaps_Contents_ContentID",
                table: "ContentTagMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentTagMaps_Tags_TagID",
                table: "ContentTagMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_FirmDocs_Contents_ContentID",
                table: "FirmDocs");

            migrationBuilder.RenameColumn(
                name: "ToAdress",
                table: "Notifications",
                newName: "TOADRESS");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Notifications",
                newName: "SUBJECT");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Notifications",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "RetryCount",
                table: "Notifications",
                newName: "RETRYCOUNT");

            migrationBuilder.RenameColumn(
                name: "IsDelivered",
                table: "Notifications",
                newName: "ISDELIVERED");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Notifications",
                newName: "BODY");

            migrationBuilder.RenameColumn(
                name: "EmailQueueID",
                table: "Notifications",
                newName: "EMAILQUEUEID");

            migrationBuilder.RenameColumn(
                name: "LastRetryDate",
                table: "Notifications",
                newName: "LASTRERYDATE");

            migrationBuilder.RenameColumn(
                name: "SenderName",
                table: "Messages",
                newName: "SENDERNAME");

            migrationBuilder.RenameColumn(
                name: "SenderMail",
                table: "Messages",
                newName: "SENDERMAIL");

            migrationBuilder.RenameColumn(
                name: "ReceiverNAme",
                table: "Messages",
                newName: "RECEIVERNAME");

            migrationBuilder.RenameColumn(
                name: "ReceiverMail",
                table: "Messages",
                newName: "RECEIVERMAIL");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Messages",
                newName: "DATE");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Messages",
                newName: "CONTENT");

            migrationBuilder.RenameColumn(
                name: "MessageID",
                table: "Messages",
                newName: "MESSAGEID");

            migrationBuilder.RenameColumn(
                name: "IMGData",
                table: "FirmDocs",
                newName: "IMGDATA");

            migrationBuilder.RenameColumn(
                name: "ContentID",
                table: "FirmDocs",
                newName: "CONTENTID");

            migrationBuilder.RenameColumn(
                name: "ImgID",
                table: "FirmDocs",
                newName: "IMGID");

            migrationBuilder.RenameIndex(
                name: "IX_FirmDocs_ContentID",
                table: "FirmDocs",
                newName: "IX_FirmDocs_CONTENTID");

            migrationBuilder.RenameColumn(
                name: "TagID",
                table: "ContentTagMaps",
                newName: "TAGID");

            migrationBuilder.RenameColumn(
                name: "ContentID",
                table: "ContentTagMaps",
                newName: "CONTENTID");

            migrationBuilder.RenameColumn(
                name: "MapId",
                table: "ContentTagMaps",
                newName: "MAPID");

            migrationBuilder.RenameIndex(
                name: "IX_ContentTagMaps_TagID",
                table: "ContentTagMaps",
                newName: "IX_ContentTagMaps_TAGID");

            migrationBuilder.RenameIndex(
                name: "IX_ContentTagMaps_ContentID",
                table: "ContentTagMaps",
                newName: "IX_ContentTagMaps_CONTENTID");

            migrationBuilder.RenameColumn(
                name: "Town",
                table: "Contents",
                newName: "TOWN");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Contents",
                newName: "TITLE");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Contents",
                newName: "PRICE");

            migrationBuilder.RenameColumn(
                name: "NumberOfRooms",
                table: "Contents",
                newName: "NUMBEROFROOMS");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Contents",
                newName: "ISACTIVE");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Contents",
                newName: "DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Contents",
                newName: "CREATEDDATE");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Contents",
                newName: "COUNTRY");

            migrationBuilder.RenameColumn(
                name: "ContentType",
                table: "Contents",
                newName: "CONTENTTYPE");

            migrationBuilder.RenameColumn(
                name: "ContentFrom",
                table: "Contents",
                newName: "CONTENTFROM");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Contents",
                newName: "CITY");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Contents",
                newName: "CATEGORYID");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Contents",
                newName: "ADRESS");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_CategoryID",
                table: "Contents",
                newName: "IX_Contents_CATEGORYID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "ContentQuestions",
                newName: "USERID");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ContentQuestions",
                newName: "DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "ContentID",
                table: "ContentQuestions",
                newName: "CONTENTID");

            migrationBuilder.RenameColumn(
                name: "QuestionID",
                table: "ContentQuestions",
                newName: "QUESTIONID");

            migrationBuilder.RenameIndex(
                name: "IX_ContentQuestions_ContentID",
                table: "ContentQuestions",
                newName: "IX_ContentQuestions_CONTENTID");

            migrationBuilder.RenameColumn(
                name: "ViewCount",
                table: "ContentInteractions",
                newName: "VIEWCOUNT");

            migrationBuilder.RenameColumn(
                name: "FavoriteCount",
                table: "ContentInteractions",
                newName: "FAVORITECOUNT");

            migrationBuilder.RenameColumn(
                name: "ContentID",
                table: "ContentInteractions",
                newName: "CONTENTID");

            migrationBuilder.RenameColumn(
                name: "InteractionID",
                table: "ContentInteractions",
                newName: "INTERACTIONID");

            migrationBuilder.RenameIndex(
                name: "IX_ContentInteractions_ContentID",
                table: "ContentInteractions",
                newName: "IX_ContentInteractions_CONTENTID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "ContentAnswers",
                newName: "USERID");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ContentAnswers",
                newName: "DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "ContentID",
                table: "ContentAnswers",
                newName: "CONTENTID");

            migrationBuilder.RenameColumn(
                name: "AnswerID",
                table: "ContentAnswers",
                newName: "ANSWERID");

            migrationBuilder.RenameIndex(
                name: "IX_ContentAnswers_ContentID",
                table: "ContentAnswers",
                newName: "IX_ContentAnswers_CONTENTID");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "AspNetUsers",
                newName: "SURNAME");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "AspNetUsers",
                newName: "ISACTIVE");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentAnswers_Contents_CONTENTID",
                table: "ContentAnswers",
                column: "CONTENTID",
                principalTable: "Contents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentInteractions_Contents_CONTENTID",
                table: "ContentInteractions",
                column: "CONTENTID",
                principalTable: "Contents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentQuestions_Contents_CONTENTID",
                table: "ContentQuestions",
                column: "CONTENTID",
                principalTable: "Contents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_ContentCategories_CATEGORYID",
                table: "Contents",
                column: "CATEGORYID",
                principalTable: "ContentCategories",
                principalColumn: "CATEGORYID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentTagMaps_Contents_CONTENTID",
                table: "ContentTagMaps",
                column: "CONTENTID",
                principalTable: "Contents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentTagMaps_Tags_TAGID",
                table: "ContentTagMaps",
                column: "TAGID",
                principalTable: "Tags",
                principalColumn: "TAGID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FirmDocs_Contents_CONTENTID",
                table: "FirmDocs",
                column: "CONTENTID",
                principalTable: "Contents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
