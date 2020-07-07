using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EligoCustomerPortal.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Residential" },
                    { 2, "Commercial" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "City", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Chicago", "60606", "IL", "201 West Lake Street" },
                    { 2, "Chicago", "60606", "IL", "333 West Wacker Drive" },
                    { 3, "Chicago", "60606", "IL", "233 South Wacker Drive" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "EmailAddress", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ericgomoll@gmail.com", "Eric", "Gomoll", "(847) 722-9149" },
                    { 2, "dsoderna@eligoenergy.com", "David", "Solderna", null }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Credit Card" },
                    { 2, "Check" },
                    { 3, "Cash" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "AccountTypeID", "AddressID", "BillingAddressID", "CustomerID", "ServiceAddressID" },
                values: new object[] { 101, 1, null, 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "AccountTypeID", "AddressID", "BillingAddressID", "CustomerID", "ServiceAddressID" },
                values: new object[] { 102, 1, null, 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "AccountTypeID", "AddressID", "BillingAddressID", "CustomerID", "ServiceAddressID" },
                values: new object[] { 103, 2, null, 1, 2, 3 });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "ID", "AccountID", "Amount", "InvoiceDate", "IsPaid" },
                values: new object[,]
                {
                    { 5544, 101, 124.54m, new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 6062, 101, 117.01m, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 6098, 101, 135.04m, new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 5334, 102, 79.76m, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 6097, 102, 114.54m, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 6114, 102, 122.00m, new DateTime(2020, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 5495, 103, 145.43m, new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 6113, 103, 176.04m, new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 6122, 103, 191.01m, new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "ID", "Amount", "InvoiceID", "PaymentDate", "PaymentMethodID" },
                values: new object[,]
                {
                    { 4432, 124.54m, 5544, new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4954, 117.01m, 6062, new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4345, 79.76m, 5334, new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4957, 114.54m, 6097, new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4309, 145.43m, 5495, new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5005, 176.04m, 6113, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5109, 191.01m, 6122, new DateTime(2020, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "ID",
                keyValue: 6098);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "ID",
                keyValue: 6114);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "ID",
                keyValue: 4309);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "ID",
                keyValue: 4345);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "ID",
                keyValue: 4432);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "ID",
                keyValue: 4954);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "ID",
                keyValue: 4957);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "ID",
                keyValue: 5005);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "ID",
                keyValue: 5109);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "ID",
                keyValue: 5334);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "ID",
                keyValue: 5495);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "ID",
                keyValue: 5544);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "ID",
                keyValue: 6062);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "ID",
                keyValue: 6097);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "ID",
                keyValue: 6113);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "ID",
                keyValue: 6122);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "ID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "ID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "ID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
