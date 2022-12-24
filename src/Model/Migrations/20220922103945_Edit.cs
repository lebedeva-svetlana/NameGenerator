using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    language_name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_language", x => x.language_id);
                });

            migrationBuilder.CreateTable(
                name: "endings_type",
                columns: table => new
                {
                    endings_type_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    language_id = table.Column<int>(type: "INTEGER", nullable: false),
                    endings_type_name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_endings_type", x => x.endings_type_id);
                    table.ForeignKey(
                        name: "fk_language_endings_type",
                        column: x => x.language_id,
                        principalTable: "language",
                        principalColumn: "language_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "frequency_type",
                columns: table => new
                {
                    frequency_type_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    language_id = table.Column<int>(type: "INTEGER", nullable: false),
                    frequency_type_name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_frequency_type", x => x.frequency_type_id);
                    table.ForeignKey(
                        name: "fk_language_frequency_type",
                        column: x => x.language_id,
                        principalTable: "language",
                        principalColumn: "language_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "letter",
                columns: table => new
                {
                    letter_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    language_id = table.Column<int>(type: "INTEGER", nullable: false),
                    @char = table.Column<char>(name: "char", type: "TEXT", maxLength: 1, nullable: false),
                    is_vowel = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_letter", x => x.letter_id);
                    table.CheckConstraint("ch_is_vowel", "is_vowel IN (0, 1)");
                    table.ForeignKey(
                        name: "fk_language_letter",
                        column: x => x.language_id,
                        principalTable: "language",
                        principalColumn: "language_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "endings",
                columns: table => new
                {
                    endings_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    endings_type_id = table.Column<int>(type: "INTEGER", nullable: false),
                    ending = table.Column<string>(type: "TEXT", nullable: false),
                    is_female_ending = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_endings", x => x.endings_id);
                    table.CheckConstraint("ch_is_female_ending", "is_female_ending IN (0, 1)");
                    table.ForeignKey(
                        name: "fk_endings_type_endings",
                        column: x => x.endings_type_id,
                        principalTable: "endings_type",
                        principalColumn: "endings_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "letter_frequency",
                columns: table => new
                {
                    frequency_type_id = table.Column<int>(type: "INTEGER", nullable: false),
                    letter_id = table.Column<int>(type: "INTEGER", nullable: false),
                    frequency = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_letter_frequency", x => new { x.frequency_type_id, x.letter_id });
                    table.CheckConstraint("ch_frequency", "frequency >= 0");
                    table.ForeignKey(
                        name: "fk_frequency_type_letter_frequency",
                        column: x => x.frequency_type_id,
                        principalTable: "frequency_type",
                        principalColumn: "frequency_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_letter_letter_frequency",
                        column: x => x.letter_id,
                        principalTable: "letter",
                        principalColumn: "letter_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "language",
                columns: new[] { "language_id", "language_name" },
                values: new object[] { 1, "Russian" });

            migrationBuilder.InsertData(
                table: "endings_type",
                columns: new[] { "endings_type_id", "endings_type_name", "language_id" },
                values: new object[] { 1, "Standard", 1 });

            migrationBuilder.InsertData(
                table: "frequency_type",
                columns: new[] { "frequency_type_id", "frequency_type_name", "language_id" },
                values: new object[] { 1, "Standard", 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 29, 'э', true, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 28, 'ы', true, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 27, 'щ', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 26, 'ш', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 25, 'ч', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 24, 'ц', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 23, 'х', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 22, 'ф', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 21, 'у', true, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 20, 'т', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 19, 'с', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 18, 'р', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 17, 'п', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 16, 'о', true, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 15, 'н', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 14, 'м', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 13, 'л', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 12, 'к', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 11, 'й', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 10, 'и', true, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 9, 'з', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 8, 'ж', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 7, 'ё', true, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 6, 'е', true, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 5, 'д', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 4, 'г', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 3, 'в', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 2, 'б', false, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 1, 'а', true, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 30, 'ю', true, 1 });

            migrationBuilder.InsertData(
                table: "letter",
                columns: new[] { "letter_id", "char", "is_vowel", "language_id" },
                values: new object[] { 31, 'я', true, 1 });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 1, "а", 1, true });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 30, "х", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 29, "ф", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 28, "т", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 27, "с", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 26, "р", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 25, "п", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 24, "н", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 23, "м", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 21, "к", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 20, "й", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 19, "ж", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 18, "д", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 17, "г", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 16, "в", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 22, "л", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 14, "эя", 1, true });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 15, "б", 1, false });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 3, "и", 1, true });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 4, "о", 1, true });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 5, "у", 1, true });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 6, "э", 1, true });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 7, "ю", 1, true });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 2, "е", 1, true });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 9, "ая", 1, true });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 10, "ея", 1, true });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 11, "ия", 1, true });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 12, "оя", 1, true });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 13, "уя", 1, true });

            migrationBuilder.InsertData(
                table: "endings",
                columns: new[] { "endings_id", "ending", "endings_type_id", "is_female_ending" },
                values: new object[] { 8, "я", 1, true });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 18, 473 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 19, 547 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 20, 626 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 21, 262 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 22, 26 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 23, 97 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 26, 23 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 25, 34 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 27, 26 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 28, 190 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 29, 32 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 17, 281 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 24, 38 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 16, 1097 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 1, 801 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 14, 321 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 13, 440 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 12, 349 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 11, 121 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 10, 735 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 9, 165 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 8, 94 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 7, 4 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 6, 845 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 5, 298 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 4, 170 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 3, 454 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 2, 159 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 30, 64 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 15, 670 });

            migrationBuilder.InsertData(
                table: "letter_frequency",
                columns: new[] { "frequency_type_id", "letter_id", "frequency" },
                values: new object[] { 1, 31, 201 });

            migrationBuilder.CreateIndex(
                name: "IX_endings_endings_type_id",
                table: "endings",
                column: "endings_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_endings_type_language_id",
                table: "endings_type",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_frequency_type_frequency_type_name",
                table: "frequency_type",
                column: "frequency_type_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_frequency_type_language_id",
                table: "frequency_type",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_language_language_name",
                table: "language",
                column: "language_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_letter_char",
                table: "letter",
                column: "char",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_letter_language_id",
                table: "letter",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_letter_frequency_letter_id",
                table: "letter_frequency",
                column: "letter_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "endings");

            migrationBuilder.DropTable(
                name: "letter_frequency");

            migrationBuilder.DropTable(
                name: "endings_type");

            migrationBuilder.DropTable(
                name: "frequency_type");

            migrationBuilder.DropTable(
                name: "letter");

            migrationBuilder.DropTable(
                name: "language");
        }
    }
}
