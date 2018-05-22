using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RazorPagesMovie.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Genre = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }

        private void UpdateData(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                USE [MovieDevDb]
                                GO
                                
                                -- Truncate current data
                                TRUNCATE TABLE MOVIE
                                
                                -- Insert data
                                SET IDENTITY_INSERT [dbo].[Movie] ON                                 
                                GO

                                INSERT [dbo].[Movie] ([Id], [Genre], [Price], [ReleaseDate], [Title]) VALUES (1, N'Romantic Comedy', CAST(7.99 AS Decimal(18, 2)), CAST(N'1989-02-12 00:00:00.0000000' AS DateTime2), N'When Harry Met Sally')
                                GO

                                INSERT [dbo].[Movie] ([Id], [Genre], [Price], [ReleaseDate], [Title]) VALUES (2, N'Comedy', CAST(8.99 AS Decimal(18, 2)), CAST(N'1984-03-13 00:00:00.0000000' AS DateTime2), N'Ghostbusters')
                                GO
                                
                                INSERT [dbo].[Movie] ([Id], [Genre], [Price], [ReleaseDate], [Title]) VALUES (3, N'Comedy', CAST(9.99 AS Decimal(18, 2)), CAST(N'1986-02-23 00:00:00.0000000' AS DateTime2), N'Ghostbusters 2')
                                GO
                                
                                INSERT [dbo].[Movie] ([Id], [Genre], [Price], [ReleaseDate], [Title]) VALUES (4, N'Western', CAST(3.99 AS Decimal(18, 2)), CAST(N'1959-04-15 00:00:00.0000000' AS DateTime2), N'Rio Bravo')
                                GO
                                
                                SET IDENTITY_INSERT [dbo].[Movie] OFF
                                GO");
        }

        private void RollbackData(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"TRUNCATE TABLE MOVIE");
        }
    }
}
