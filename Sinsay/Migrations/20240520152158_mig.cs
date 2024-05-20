using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sinsay.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PickupPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickupPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PickupPoints_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    LastVisit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isBloced = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    PickupPointId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PickupPoints_PickupPointId",
                        column: x => x.PickupPointId,
                        principalTable: "PickupPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ClothersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Clothes_ClothersId",
                        column: x => x.ClothersId,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Москва" },
                    { 2, "Санкт-Петербург" },
                    { 3, "Адыгея" },
                    { 4, "Альметьевск" },
                    { 5, "Ангарск" },
                    { 6, "Арзамас" },
                    { 7, "Армавир" },
                    { 8, "Архангельск" },
                    { 9, "Астрахань" },
                    { 10, "Балаково" },
                    { 11, "Балашов" },
                    { 12, "Барабинск" },
                    { 13, "Барнаул" },
                    { 14, "Белгород" },
                    { 15, "Белебей" },
                    { 16, "Бердск" },
                    { 17, "Благовещенск" },
                    { 18, "Брянск" },
                    { 19, "Бугульма" },
                    { 20, "Великий Новгород" },
                    { 21, "Видное" },
                    { 22, "Владивосток" },
                    { 23, "Владикавказ" },
                    { 24, "Владимир" },
                    { 25, "Волгоград" },
                    { 26, "Волгодонск" },
                    { 27, "Волжский" },
                    { 28, "Воронеж" },
                    { 29, "Гатчина" },
                    { 30, "Грозный" },
                    { 31, "Десногорск" },
                    { 32, "Дзержинск" },
                    { 33, "Димитровград" },
                    { 34, "Домодедово" },
                    { 35, "Екатеринбург" },
                    { 36, "Жигулевск" },
                    { 37, "Иваново" },
                    { 38, "Ижевск" },
                    { 39, "Иркутск" },
                    { 40, "Йошкар-Ола" },
                    { 41, "Казань" },
                    { 42, "Калининград" },
                    { 43, "Калуга" },
                    { 44, "Кемерово" },
                    { 45, "Лениногорск" }
                });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "Count", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 100, "сиреневый 40", "Платье-кардиган П 12 ", 1100m },
                    { 2, 100, "черный 42", "Платье П 49 ", 990m },
                    { 3, 100, "лиловый 42", "Платье П 50 ", 1200m },
                    { 4, 100, "бордо 46", "Платье П 59 ", 1500m },
                    { 5, 100, "черный + красный 46", "Платье П 27 ", 500m },
                    { 6, 100, "красный 40", "Платье-кардиган П 12 ", 1100m },
                    { 7, 100, "синий 40", "Платье-кардиган П 12 ", 1100m },
                    { 8, 100, "серый+черный 42", "Платье П 32 ", 1200m },
                    { 9, 100, "розовый 42", "Пляжная накидка П 38 ", 700m },
                    { 10, 100, "фуксия 46", "Платье П 02 ", 900m },
                    { 11, 100, "хаки 42", "Платье П 58 ", 1200m },
                    { 12, 100, "черный 40", "Платье П 15 ", 1000m },
                    { 13, 100, "лимонный 48", "Платье П 28 ", 1300m },
                    { 14, 100, "красный 42", "Платье-кардиган П 12 ", 1100m },
                    { 15, 100, "сиреневый 42", "Платье-кардиган П 12 ", 1100m },
                    { 16, 100, "черный 44", "Платье П 49 ", 990m },
                    { 17, 100, "ментол 50", "Сарафан П 48 ", 800m },
                    { 18, 100, "розовый 44", "Пляжная накидка П 38 ", 700m },
                    { 19, 100, "черный 42", "Платье П 15 ", 1000m },
                    { 20, 100, "серый+черный 44", "Платье П 32 ", 1200m },
                    { 21, 100, "серый 44", "Платье П 46 ", 990m },
                    { 22, 100, "фуксия 50", "Платье П 02 ", 900m },
                    { 23, 100, "лимонный 50", "Платье П 28 ", 1300m },
                    { 24, 100, "хвойный 52", "Платье П 59 ", 1500m },
                    { 25, 100, "серый+черный 54", "Платье П 32 ", 1200m },
                    { 26, 100, "хаки 46", "Платье П 58 ", 1200m },
                    { 27, 100, "серый 46", "Платье П 46 ", 990m },
                    { 28, 100, "темно-синий 46", "Платье П 59 ", 1500m },
                    { 29, 100, "сиреневый 44", "Платье-кардиган П 12 ", 1100m },
                    { 30, 100, "лиловый 46", "Платье П 50 ", 1200m },
                    { 31, 100, "черный 44", "Платье П 15 ", 1000m },
                    { 32, 100, "красный 50", "Платье П 02 ", 900m },
                    { 33, 100, "серый+черный 56", "Платье П 32 ", 1200m },
                    { 34, 100, "лимонный 52", "Платье П 28 ", 1300m },
                    { 35, 100, "красный 40", "Платье П 11 ", 1100m },
                    { 36, 100, "красный 42", "Платье П 11 ", 1100m },
                    { 37, 100, "красный 44", "Платье П 11 ", 1100m },
                    { 38, 100, "красный 46", "Платье П 11 ", 1100m },
                    { 39, 100, "индиго 4.1 M ", "Футболка мужская Ф 24 ", 1300m },
                    { 40, 100, "сиреневый 9.1 XXL ", "Футболка мужская Ф 23 ", 1350m },
                    { 41, 100, "голубой6 XXL ", "Футболка мужская Ф 23 ", 1350m },
                    { 42, 100, "сиреневый7.1 XXL ", "Футболка мужская Ф 23 ", 1350m },
                    { 43, 100, "белый ONE SIZE ", "Шапка бини В 03 ", 500m },
                    { 44, 100, "бордо ONE SIZE ", "Шапка бини В 03 ", 500m },
                    { 45, 100, "розовый ONE SIZE ", "Шапка бини В 03 ", 500m },
                    { 46, 100, "розовый ONE SIZE ", "Шапка бини В 02 ", 500m },
                    { 47, 100, "синий ONE SIZE ", "Шапка бини В 03 ", 500m },
                    { 48, 100, "серый ONE SIZE ", "Шапка бини В 02 ", 500m },
                    { 49, 100, "голубой 6 XXL ", "Блузка Ф 04 46", 500m },
                    { 50, 100, "индиго 4.1 M ", "Блузка Ф 01 44", 502m },
                    { 51, 100, "розовый 52-54", "Блузка Ф 01 46", 502m },
                    { 52, 100, "горошек 44", "Блузка Ф 02 ", 550m },
                    { 53, 100, "черный 58", "Блузка Ф 08 ", 650m },
                    { 54, 100, "лиловый 44", "Блузка Ф 13 ", 750m },
                    { 55, 100, "лиловый 46", "Блузка Ф 13 ", 750m },
                    { 56, 100, "лиловый 50", "Блузка Ф 13 ", 750m },
                    { 57, 100, "лиловый 56", "Блузка Ф 13 ", 750m },
                    { 58, 100, "светло-зеленый 50", "Блузка Ф 13 ", 750m },
                    { 59, 100, "светло-зеленый 54", "Блузка Ф 13 ", 750m },
                    { 60, 100, "светло-зеленый 58", "Блузка Ф 13 ", 750m },
                    { 61, 100, "розовый 40-42", "Футболка Ф 18 ", 516m },
                    { 62, 100, "розовый 44-46", "Футболка Ф 18 ", 516m },
                    { 63, 100, "розовый 52-54", "Футболка Ф 18 ", 516m },
                    { 64, 100, "розовый 44-46", "Футболка Ф 19 ", 502m },
                    { 65, 100, "розовый 48-50", "Футболка Ф 19 ", 502m },
                    { 66, 100, "розовый 52-54", "Футболка Ф 19 ", 502m },
                    { 67, 100, "индиго4.1 M ", "Футболка мужская Ф 24 ", 1300m },
                    { 68, 100, "сиреневый7.1 XXL ", "Футболка мужская Ф 23 ", 1350m },
                    { 69, 100, "сиреневый9.1 XXL ", "Футболка мужская Ф 23 ", 1350m },
                    { 70, 100, "голубой6 XXL ", "Футболка мужская Ф 23 ", 1350m },
                    { 71, 100, "розовый 42", "Толстовка Ф 14 ", 1033m },
                    { 72, 100, "хаки 42", "Толстовка Ф 14 ", 1033m },
                    { 73, 100, "ментол 62", "Худи Ф 20 ", 900m },
                    { 74, 100, "хаки 44", "Толстовка Ф 14 ", 1033m },
                    { 75, 100, "ментол 64", "Худи Ф 20 ", 900m },
                    { 76, 100, "розовый 44", "Толстовка Ф 14 ", 1033m },
                    { 77, 100, "ментол 66", "Худи Ф 20 ", 900m },
                    { 78, 100, "хаки 46", "Толстовка Ф 14 ", 1033m },
                    { 79, 100, "хаки 48", "Толстовка Ф 14 ", 1033m },
                    { 80, 100, "розовый 48", "Толстовка Ф 14 ", 1033m },
                    { 81, 100, "розовый 50", "Толстовка Ф 14 ", 1033m },
                    { 82, 100, "розовый 52", "Толстовка Ф 14 ", 1033m },
                    { 83, 100, "хаки 52", "Толстовка Ф 14 ", 1033m },
                    { 84, 100, "персиковый 42", "Костюм К 25 ", 610m },
                    { 85, 100, "синий 42", "Костюм К 17 ", 1500m },
                    { 86, 100, "персиковый 46", "Костюм К 25 ", 610m },
                    { 87, 100, "синий 46", "Костюм К 17 ", 1500m },
                    { 88, 100, "синий 48", "Костюм К 17 ", 1500m },
                    { 89, 100, "персиковый 48", "Костюм К 25 ", 610m },
                    { 90, 100, "синий 50", "Костюм К 17 ", 1500m },
                    { 91, 100, "персиковый 50", "Костюм К 25 ", 610m },
                    { 92, 100, "синий 52", "Костюм К 17 ", 1500m },
                    { 93, 100, "ментол 52", "Костюм К 07 ", 1300m },
                    { 94, 100, "персиковый 52", "Костюм К 25 ", 610m },
                    { 95, 100, "розовый 42", "Костюм К 07 ", 1300m },
                    { 96, 100, "розовый 46", "Костюм К 07 ", 1300m },
                    { 97, 100, "розовый 50", "Костюм К 07 ", 1300m },
                    { 98, 100, "розовый 52", "Костюм К 07 ", 1300m },
                    { 99, 100, "розовый 42", "Костюм К 12 ", 1200m },
                    { 100, 100, "красный 42", "Костюм К 17 ", 1500m },
                    { 101, 100, "красный 46", "Костюм К 17 ", 1500m },
                    { 102, 100, "василек 42", "Костюм К 17 ", 1500m },
                    { 103, 100, "василек 46", "Костюм К 17 ", 1500m },
                    { 104, 100, "василек 50", "Костюм К 17 ", 1500m },
                    { 105, 100, "василек 52", "Костюм К 17 ", 1500m },
                    { 106, 100, "малиновый 42", "Брюки Ш 01 ", 700m },
                    { 107, 100, "сиреневый 42", "Брюки Ш 01 ", 700m },
                    { 108, 100, "сиреневый 44", "Брюки Ш 01 ", 700m },
                    { 109, 100, "василек 44", "Брюки Ш 01 ", 700m },
                    { 110, 100, "малиновый 46", "Брюки Ш 01 ", 700m },
                    { 111, 100, "василек 46", "Брюки Ш 01 ", 700m },
                    { 112, 100, "красная замша 46", "Брюки Ш 01 ", 800m },
                    { 113, 100, "малиновый 48", "Брюки Ш 01 ", 700m },
                    { 114, 100, "василек 48", "Брюки Ш 01 ", 700m },
                    { 115, 100, "малиновый 52", "Брюки Ш 01 ", 700m },
                    { 116, 100, "красный 42", "Брюки Ш 01 ", 700m },
                    { 117, 100, "красный 44", "Брюки Ш 01 ", 700m },
                    { 118, 100, "красный 46", "Брюки Ш 01 ", 700m },
                    { 119, 100, "красный 50", "Брюки Ш 01 ", 700m },
                    { 120, 100, "оранжевый 116см", "Детская футболка ДФ 01 ", 215m },
                    { 121, 100, "фиолетовый 116см", "Детская футболка ДФ 01 ", 215m },
                    { 122, 100, "оранжевый 122см", "Детская футболка ДФ 01 ", 215m },
                    { 123, 100, "фиолетовый 122см", "Детская футболка ДФ 01 ", 215m },
                    { 124, 100, "оранжевый 128см", "Детская футболка ДФ 01 ", 215m },
                    { 125, 100, "фиолетовый 128см", "Детская футболка ДФ 01 ", 215m },
                    { 126, 100, "фиолетовый 134см", "Детская футболка ДФ 01 ", 215m },
                    { 127, 100, "оранжевый 134см", "Детская футболка ДФ 01 ", 215m },
                    { 128, 100, "оранжевый 140см", "Детская футболка ДФ 01 ", 215m },
                    { 129, 100, "фиолетовый 140см", "Детская футболка ДФ 01 ", 215m }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Принят в обработку" },
                    { 2, "Подтверждён" },
                    { 3, "Доставляется в ПВЗ" },
                    { 4, "Готов к выдаче" },
                    { 5, "Отменён" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Оплата картой при получении" },
                    { 2, "Оплата наличными при получении" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "PickupPoints",
                columns: new[] { "Id", "Address", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, "Московская область, п. Вешки, 1-й километр шоссе, 3с1", 1, "ТЦ Весна" },
                    { 2, "Автозаводская улица, 18", 1, "ТЦ Ривьера" },
                    { 3, "Ходынский б-р, 4", 1, "ТЦ Авиапарк" },
                    { 4, "Московская область, г. Котельники, 1-й Покровский проезд, 5", 1, "ТЦ МЕГА Белая Дача" },
                    { 5, "Московская область, п. Совхоз им. Ленина, 24-й километр МКАД, 1", 1, "ТЦ Вегас" },
                    { 6, "п. Московский, 23-ий км. Киевское шоссе, 1", 1, "ТЦ Саларис" },
                    { 7, "Дмитрия Донского б-р, 1", 1, "ТЦ Северное Сияние" },
                    { 8, "Кировоградская улица, 13А", 1, "ТЦ Колумбус" },
                    { 9, "Аминьевско шоссе, 6", 1, "ТЦ Квартал" },
                    { 10, "Мира пр-кт, 211к2", 1, "ТЦ Европолис" },
                    { 11, "7-я Кожуховская улица, 9", 1, "ТЦ Мозаика" },
                    { 12, "Сущёвский Вал улица, 5 с 1А", 1, "ТЦ Савеловский" },
                    { 13, "Рязанский пр-кт, 2К2", 1, "ТЦ Город на Рязанке" },
                    { 14, "Каховка улица, 29А", 1, "ТЦ Прайм Плаза" },
                    { 15, "Дмитровское шоссе, 163А", 1, "ТЦ Рио" },
                    { 16, "Энтузиастов шоссе, 12к2", 1, "ТЦ Город Лефортово" },
                    { 17, "Маршала Бирюзова улица, 32", 1, "ТЦ 5 Авеню" },
                    { 18, "Сиреневый б-р, 31", 1, "ТЦ София" },
                    { 19, "Авиаторов улица, 3А", 1, "ТЦ Небо" },
                    { 20, "Новоухтомское шоссе, 2А стр.2", 1, "ТЦ Город Косино» " },
                    { 21, "г. Солнечногорск, 2-й мкр., С20", 1, "ТЦ Зеленопарк" },
                    { 22, "Ленинский проспект, 123В", 1, "ТЦ Галеон" },
                    { 23, "Коммунистическая ул., 1", 1, "ТЦ XL" },
                    { 24, "Ореховый бул., 22а", 1, "ТЦ Облака" },
                    { 25, "Ленинградская область, г. Кудрово, 12-й км. Мурманское шоссе, 1", 2, "ТЦ МЕГА Дыбенко" },
                    { 26, "Лиговский пр-кт, 30а", 2, "ТЦ Галерея" },
                    { 27, "Петергофское шоссе, 51", 2, "ТЦ Жемчужина Плаза" },
                    { 28, "Комендантская площадь, 1", 2, "ТЦ Атмосфера" },
                    { 29, "Балканская площадь, 5Ю", 2, "ТЦ Балкания" },
                    { 30, "Стачек пр-кт, 99", 2, "ТЦ Континент" },
                    { 31, "Савушкина улица, 141", 2, "ТЦ Меркурий" },
                    { 32, "Брантовская дорога, 3", 2, "ТЦ Охта Молл" },
                    { 33, "Энгельса пр-кт, 154", 2, "ТЦ Гранд Каньон" },
                    { 34, "Торфяная дорога, 7Т", 2, "ТЦ Гулливер" },
                    { 35, "Индустриальный пр-кт, 31", 2, "ТЦ Индустриальный" },
                    { 36, "Ленсовета улица, 97", 2, "ТЦ Континент на Звездной" },
                    { 37, "Белы Куна улица, 3", 2, "ТЦ Международный" },
                    { 38, "Фучика улица, 2", 2, "ТЦ Рио" },
                    { 39, "Большая Разночинная улица, 16", 2, "ТЦ Чкаловский" },
                    { 40, "Просвещения пр-кт, 80к1", 2, "ТЦ Прометей" },
                    { 41, "Типанова улица, 27/39", 2, "ТЦ Космос" },
                    { 42, "Приморский пр-кт, 72", 2, "ТЦ Питерлэнд" },
                    { 43, "Космонавтов пр-кт, 14", 2, "ТЦ Питер Радуга" },
                    { 44, "Тургеньевское ш., 27", 4, "ТЦ Мега" },
                    { 45, "ул. Ризы Фахретдина, 7", 5, "ТЦ Девонский" },
                    { 46, "192-й квартал, 12", 6, "ТЦ Фестиваль" },
                    { 47, "Ленина пр-кт, 200Б", 7, "ТЦ Авеню" },
                    { 48, "ул. Воровского, 69", 8, "ТЦ Красная площадь" },
                    { 49, "Ленинградский пр-кт, 38", 9, "ТЦ Макси" },
                    { 50, "ул. Советская, 25", 9, "ТЦ Соломбала Молл" },
                    { 51, "ул. Минусинская, 8", 9, "ТЦ Три кота" },
                    { 52, "ул. Магистральная, 29", 9, "ТЦ Декстер" },
                    { 53, "ул. Савушкина, 5", 9, "ТЦ Сити" },
                    { 54, "ул. Боевая, 25", 9, "ТЦ Алимпик" },
                    { 55, "ул. Трнавская, 24", 10, "ТЦ Green House" },
                    { 56, "ул. 30 лет Победы, 156", 11, "ТЦ Айсберг" },
                    { 57, "ул. Энтузиастов, 1", 11, "ТЦ Балашовский Пассаж" },
                    { 58, "Карла Маркса, 108", 12, "СФ Карла Маркса" },
                    { 59, "Ленина пр-кт, 102В", 13, "ТЦ Пионер" },
                    { 60, "ул. Павловский, 251А", 13, "ТЦ Лето" },
                    { 61, "пр-кт Строителей, 177", 13, "ТЦ Galaxy" },
                    { 62, "Богдана Хмельницкого пр-кт, 164", 14, "ТЦ РИО" },
                    { 63, "ул. Морозова, 9", 15, "ТЦ Эссен" },
                    { 64, "Радужный мкр., 7 к.1", 16, "ТЦ Радужный" },
                    { 65, "ул. Мухина, 114", 17, "ТЦ Острова" },
                    { 66, "ул. Объездная, 30", 18, "ТЦ Аэропарк" },
                    { 67, "ул. Ленина, 145", 19, "ТЦ Эссен" },
                    { 68, "ул. Ломоносова, 29", 20, "ТЦ Мармелад" },
                    { 69, "ул. Олимпийская, 6К1", 21, "ТЦ Галерея 9-18" },
                    { 70, "ул. Калинина, 8", 22, "ТЦ Калина Молл" },
                    { 71, "Некрасовская улица, 49А", 22, "ТЦ Море" },
                    { 72, "Московское шоссе, 3К", 22, "ТЦ Алания Молл" },
                    { 73, "ул. Астана Кесаева, 2а", 22, "ТРЦ Столица" },
                    { 74, "Тракторная улица, 45", 23, "ТЦ Мегаторг" },
                    { 75, "пр-кт Строителей, 9Б", 23, "ТЦ Черемушки" },
                    { 76, "Университетский пр-кт, 107", 24, "ТЦ Акварель" },
                    { 77, "б-р 30-летия Победы, 21", 24, "ТЦ Парк Хаус" },
                    { 78, "пр-кт им. В.И. Ленина, 54Б", 24, "ТЦ Европа Сити Молл" },
                    { 79, "ул. им. Землячки, 110Б", 24, "ТЦ Мармелад" },
                    { 80, "ул. Энтузиастов, 21В", 25, "ТЦ Олимп" },
                    { 81, "ул. Александрова, 18а", 26, "ТЦ Волга Молл" },
                    { 82, "п. Солнечный, Парковая улица, 3", 26, "ТЦ Град" },
                    { 83, "Ленинский пр-кт, 174П", 26, "ТЦ Максимир" },
                    { 84, "Московский пр-кт, 129/1", 26, "ТЦ Московский проспект" },
                    { 85, "ул. Генерала Кныша, 2а", 27, "ТЦ Пилот" },
                    { 86, "пр-кт Путина, 40", 34, "ТЦ Грозный Молл" },
                    { 87, "1-й мкр., 14а2/8", 23, "ТЦ Галактика" },
                    { 88, "ул. Гайдара, 61", 45, "ТЦ ЦУМ" },
                    { 89, "ул. Куйбышева, 170", 43, "ТЦ Астра Сити" },
                    { 90, "Краснодарская улица, 2", 23, "ТЦ Перекресток" },
                    { 91, "ул. 8 марта, 46", 23, "ТЦ Гринвич" },
                    { 92, "ул. Малышева, 5", 23, "ТЦ Алатырь" },
                    { 93, "пр-кт Космонавтов, 108д", 22, "ТЦ Веер" },
                    { 94, "ул. Вайнера, 9", 33, "ТЦ Пассаж" },
                    { 95, "ул. Щербакова, 4", 44, "ТЦ Глобус" },
                    { 96, "Московское ш., 18", 11, "ТЦ Озон" },
                    { 97, "ул. Лежневская, 55", 32, "ТЦ Тополь" },
                    { 98, "ул. 8 марта, 32", 45, "ТЦ Серебряный Город" },
                    { 99, "ул. Автозаводская, 3А", 23, "ТЦ Столица" },
                    { 100, "ул. Баранова, 87", 1, "ТЦ Матрица" },
                    { 101, "ул. 3 Июля, 25", 2, "ТЦ Квартал" },
                    { 102, "ул. Верхняя Набережная, 10", 4, "ТЦ ЯркоМолл" },
                    { 103, "ул. Сергеева, 3", 9, "ТЦ Джем Молл" },
                    { 104, "ул. Кирова, 6", 5, "ТЦ Елка" },
                    { 105, "ул. Красноармейская, 119", 2, "ТЦ Зелень" },
                    { 106, "пр-кт Победы, 91А", 4, "ТЦ Южный" },
                    { 107, "ул. Павлюхина, 91", 33, "ТЦ Казань Молл" },
                    { 108, "ул. Кул Гали, 9А", 26, "ТЦ Эссен" },
                    { 109, "ул. Юлиуса Фучика, 90", 43, "ТЦ Франт" },
                    { 110, "ул. академика Глушко, 16г", 41, "ТЦ Академик" },
                    { 111, "Ленинский пр-кт, 30", 40, "ТЦ Плаза Калининград" },
                    { 112, "п. Орловка, Приморское к-цо, 2", 32, "ТЦ Балтия Молл" },
                    { 113, "Московская улица, 338а", 23, "ТЦ Торговый Квартал" },
                    { 114, "Шахтёров пр-кт, 87", 14, "ТЦ Север" },
                    { 115, "Московский пр-кт, 19", 41, "ТЦ Лето Сити" },
                    { 116, "ул. Чайковского, 19Т", 32, "ТЦ Эссен" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastVisit", "PasswordHash", "PhoneNumber", "RoleId", "UserName", "isBloced" },
                values: new object[,]
                {
                    { 1, "admin@sinsay.ru", null, "ac9689e2272427085e35b9d3e3e8bed88cb3434828b43b86fc0596cad4c6e270", "+767644566", 1, "Админ", false },
                    { 2, "user@sinsay.ru", null, "831c237928e6212bedaa4451a514ace3174562f6761f6a157a2fe5082b36e2fb", "+789324325676", 2, "Иванов", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PickupPointId",
                table: "Orders",
                column: "PickupPointId");

            migrationBuilder.CreateIndex(
                name: "IX_PickupPoints_CityId",
                table: "PickupPoints",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_AppUserId",
                table: "ShoppingCarts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ClothersId",
                table: "ShoppingCarts",
                column: "ClothersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "PickupPoints");

            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Citys");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
