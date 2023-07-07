using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_TIcket_Booking.Migrations
{
    /// <inheritdoc />
    public partial class createDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieDetail",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDetail", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "userRegister",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRegister", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScreenDetail",
                columns: table => new
                {
                    ScreenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSeatCount = table.Column<int>(type: "int", nullable: true),
                    MovieDetailsMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenDetail", x => x.ScreenId);
                    table.ForeignKey(
                        name: "FK_ScreenDetail_MovieDetail_MovieDetailsMovieId",
                        column: x => x.MovieDetailsMovieId,
                        principalTable: "MovieDetail",
                        principalColumn: "MovieId");
                });

            migrationBuilder.CreateTable(
                name: "SeatAllocation",
                columns: table => new
                {
                    SeatNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeatStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenDetailsScreenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatAllocation", x => x.SeatNo);
                    table.ForeignKey(
                        name: "FK_SeatAllocation_ScreenDetail_ScreenDetailsScreenId",
                        column: x => x.ScreenDetailsScreenId,
                        principalTable: "ScreenDetail",
                        principalColumn: "ScreenId");
                });

            migrationBuilder.CreateTable(
                name: "BookingDeatil",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MovieDetailsMovieId = table.Column<int>(type: "int", nullable: true),
                    UserRegisterUserId = table.Column<int>(type: "int", nullable: true),
                    ScreenDetailsScreenId = table.Column<int>(type: "int", nullable: true),
                    SeatAllocatioonSeatNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDeatil", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingDeatil_MovieDetail_MovieDetailsMovieId",
                        column: x => x.MovieDetailsMovieId,
                        principalTable: "MovieDetail",
                        principalColumn: "MovieId");
                    table.ForeignKey(
                        name: "FK_BookingDeatil_ScreenDetail_ScreenDetailsScreenId",
                        column: x => x.ScreenDetailsScreenId,
                        principalTable: "ScreenDetail",
                        principalColumn: "ScreenId");
                    table.ForeignKey(
                        name: "FK_BookingDeatil_SeatAllocation_SeatAllocatioonSeatNo",
                        column: x => x.SeatAllocatioonSeatNo,
                        principalTable: "SeatAllocation",
                        principalColumn: "SeatNo");
                    table.ForeignKey(
                        name: "FK_BookingDeatil_userRegister_UserRegisterUserId",
                        column: x => x.UserRegisterUserId,
                        principalTable: "userRegister",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDeatil_MovieDetailsMovieId",
                table: "BookingDeatil",
                column: "MovieDetailsMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDeatil_ScreenDetailsScreenId",
                table: "BookingDeatil",
                column: "ScreenDetailsScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDeatil_SeatAllocatioonSeatNo",
                table: "BookingDeatil",
                column: "SeatAllocatioonSeatNo");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDeatil_UserRegisterUserId",
                table: "BookingDeatil",
                column: "UserRegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenDetail_MovieDetailsMovieId",
                table: "ScreenDetail",
                column: "MovieDetailsMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatAllocation_ScreenDetailsScreenId",
                table: "SeatAllocation",
                column: "ScreenDetailsScreenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDeatil");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "SeatAllocation");

            migrationBuilder.DropTable(
                name: "userRegister");

            migrationBuilder.DropTable(
                name: "ScreenDetail");

            migrationBuilder.DropTable(
                name: "MovieDetail");
        }
    }
}
