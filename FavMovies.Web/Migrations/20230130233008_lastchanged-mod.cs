﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testWebMVCApp.Migrations
{
    /// <inheritdoc />
    public partial class lastchangedmod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastChangedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastChangedBy",
                table: "Categories");
        }
    }
}
