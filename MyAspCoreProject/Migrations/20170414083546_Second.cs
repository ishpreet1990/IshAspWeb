using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAspCoreProject.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Serials_SerialId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "SerailId",
                table: "Episodes");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Episodes",
                newName: "EpisodeNumber");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Serials",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SerialTime",
                table: "Serials",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "SerialId",
                table: "Episodes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Serials_SerialId",
                table: "Episodes",
                column: "SerialId",
                principalTable: "Serials",
                principalColumn: "SerialId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Serials_SerialId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Serials");

            migrationBuilder.DropColumn(
                name: "SerialTime",
                table: "Serials");

            migrationBuilder.RenameColumn(
                name: "EpisodeNumber",
                table: "Episodes",
                newName: "Title");

            migrationBuilder.AlterColumn<int>(
                name: "SerialId",
                table: "Episodes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SerailId",
                table: "Episodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Serials_SerialId",
                table: "Episodes",
                column: "SerialId",
                principalTable: "Serials",
                principalColumn: "SerialId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
