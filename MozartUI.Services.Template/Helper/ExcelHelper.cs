//using NPOI.SS.UserModel;
//using NPOI.SS.Util;
//using NPOI.XSSF.UserModel;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text;

//namespace MozartUI.Services.Template.Helper
//{
//	public class ExcelHelper
//    {
//        /// <summary>
//        /// Excel Stream을 List<T>형태로 변환해줍니다.
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="stream">Excel Streme</param>
//        /// <returns>List<T> 값</returns>
//        public static IList<T> ExcelToItem<T>(Stream stream)
//        {
//            IList<T> result = new List<T>();
//            IWorkbook book = new XSSFWorkbook(stream);
//            ISheet sheet = book.GetSheetAt(0);

//            for (var i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
//            {
//                IRow row = sheet.GetRow(i);
//                var item = Activator.CreateInstance<T>();
//                var flag = false;

//                for (var j = row.FirstCellNum; j < row.LastCellNum; j++)
//                {
//                    var headerCell = sheet.GetRow(sheet.FirstRowNum).GetCell(j);
//                    if (headerCell == null) continue;
//                    string header = headerCell.StringCellValue.ReplaceAll(" ", "_");
//                    ICell cell = row.GetCell(j);
//                    if (TrySetProperty(item, header, cell))
//                    {
//                        flag = true;
//                    }
//                }
//                if (flag)
//                {
//                    result.Add(item);
//                }
//            }

//            return result;
//        }

//        /// <summary>
//        /// Excel Stream을 DataTable 형태로 변환해줍니다.
//        /// </summary>
//        /// <param name="stream"></param>
//        /// <returns>DataTable 값</returns>
//        public static DataTable ExcelToTable(Stream stream)
//        {
//            var result = new DataTable();
//            var book = new XSSFWorkbook(stream);
//            var sheet = book.GetSheetAt(0);

//            if (sheet.LastRowNum < 2) return null;

//            var headerRow = sheet.GetRow(0);
//            var valueRow = sheet.GetRow(1);
//            for (var i = headerRow.FirstCellNum; i < headerRow.LastCellNum; i++)
//            {
//                var headerCell = headerRow.GetCell(i);
//                if (headerCell == null) continue;
//                string header = headerCell.StringCellValue.ReplaceAll(" ", "_");
//                result.Columns.Add(header, GetValueType(valueRow.GetCell(i)));
//            }

//            for (var i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
//            {
//                IRow row = sheet.GetRow(i);
//                var item = result.NewRow();
//                var flag = false;

//                for (var j = row.FirstCellNum; j < row.LastCellNum; j++)
//                {
//                    var headerCell = headerRow.GetCell(j);
//                    if (headerCell == null) continue;
//                    string header = headerCell.StringCellValue;
//                    ICell cell = row.GetCell(j);
//                    if (TryGetCellValue(result.Columns[header].DataType, cell, out object obj))
//                    {
//                        flag = true;
//                    }
//                    item[header] = obj;
//                }
//                if (flag)
//                {
//                    result.Rows.Add(item);
//                }
//            }

//            return result;
//        }

//        /// <summary>
//        /// Excel Stream을 ExcelResult 형태로 변환해줍니다.
//        /// </summary>
//        /// <param name="table">Table 명</param>
//        /// <param name="provider">DB Provider</param>
//        /// <param name="connectionString">DB Connection String</param>
//        /// <param name="stream">Excel File Stream</param>
//        /// <param name="legacy">Legacy DB 여부</param>
//        /// <returns>ExcelResult 값</returns>
//        public static ExcelResult ExcelToServerTable(string table, string provider, string connectionString, Stream stream, bool legacy = false)
//        {
//            var result = new ExcelResult();

//            try
//            {
//                result.Table = DBHelper.GetSchemaTable(table, provider, connectionString, legacy);

//                var book = new XSSFWorkbook(stream);
//                var sheet = book.GetSheetAt(0);

//                if (sheet.LastRowNum < 2)
//                {
//                    result.ErrorMsg = "Excel file is empty!";
//                }

//                var headerRow = sheet.GetRow(0);
//                var errorSb = new StringBuilder();

//                for (var i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
//                {
//                    try
//                    {
//                        IRow row = sheet.GetRow(i);
//                        var item = result.Table.NewRow();
//                        var flag = false;

//                        for (var j = row.FirstCellNum; j < row.LastCellNum; j++)
//                        {
//                            var headerCell = headerRow.GetCell(j);
//                            if (headerCell == null) continue;
//                            string header = headerCell.StringCellValue.ReplaceAll(" ", "_");
//                            if (!result.Table.Columns.Contains(header)) continue;
//                            ICell cell = row.GetCell(j);
//                            if (TryGetCellValue(result.Table.Columns[header].DataType, cell, out object obj))
//                            {
//                                flag = true;
//                            }
//                            item[header] = obj;
//                        }
//                        if (flag)
//                        {
//                            result.Table.Rows.Add(item);
//                            result.SuccessCount++;
//                        }
//                        else
//                        {
//                            result.ErrorCount++;
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        result.ErrorCount++;
//                        errorSb.AppendLine();
//                        errorSb.AppendLine($"Row : {i}");
//                        errorSb.AppendLine();
//                        errorSb.AppendLine($"{ex.Message}\n\n{ex.StackTrace}");
//                        errorSb.AppendLine();
//                    }
//                    finally
//                    {
//                        result.TotalCount++;
//                    }
//                }
//                result.ErrorMsg = errorSb.ToString();
//            }
//            catch (Exception e)
//            {
//                result.ErrorMsg = $"{e.Message}\n\n{e.StackTrace}";
//            }

//            return result;
//        }

//        /// <summary>
//        /// Excel Stream을 ExcelResult 형태로 변환해줍니다.
//        /// </summary>
//        /// <param name="table">Table 명</param>
//        /// <param name="provider">DB Provider</param>
//        /// <param name="connectionString">DB Connection String</param>
//        /// <param name="dataList">Excel Text</param>
//        /// <param name="legacy">Legacy DB 여부</param>
//        /// <returns>ExcelResult 값</returns>
//        public static ExcelResult TextToServerTable(string table, string provider, string connectionString, string[] dataList, bool legacy = false)
//        {
//            var result = new ExcelResult();

//            try
//            {
//                result.Table = DBHelper.GetSchemaTable(table, provider, connectionString, legacy);

//                int headerIndex = FindHeaderLineIndex(result.Table, dataList);

//                if (headerIndex < 0)
//                {
//                    result.ErrorMsg = "Excel file is empty!";
//                }

//                var errorSb = new StringBuilder();
//                var columns = GetColumns(result.Table, dataList[headerIndex]);

//                for (int i = headerIndex + 1; i < dataList.Length; i++)
//                {
//                    try
//                    {
//                        string data = dataList[i];
//                        if (string.IsNullOrEmpty(data))
//                            continue;

//                        var datas = data.Split('\t');

//                        int nullcnt = 0;
//                        for (int j = 0; j < datas.Length; j++)
//                        {
//                            if (datas[j].Trim().Length == 0)
//                                nullcnt++;
//                        }

//                        if (nullcnt >= columns.Length)
//                            continue;

//                        var row = result.Table.NewRow();

//                        for (int j = 0; j < datas.Length; j++)
//                        {
//                            if (j >= columns.Length)
//                                continue;

//                            var col = columns[j];
//                            if (col == null)
//                                continue;

//                            row[col] = ConvertType(datas[j], col.DataType, DBNull.Value);
//                        }

//                        result.Table.Rows.Add(row);
//                    }
//                    catch (Exception ex)
//                    {
//                        result.ErrorCount++;
//                        errorSb.AppendLine();
//                        errorSb.AppendLine($"Row : {i}");
//                        errorSb.AppendLine();
//                        errorSb.AppendLine($"{ex.Message}\n\n{ex.StackTrace}");
//                        errorSb.AppendLine();
//                    }
//                    finally
//                    {
//                        result.TotalCount++;
//                    }
//                }

//                result.ErrorMsg = errorSb.ToString();
//            }
//            catch (Exception e)
//            {
//                result.ErrorMsg = $"{e.Message}\n\n{e.StackTrace}";
//            }

//            return result;
//        }

//        /// <summary>
//        /// Data를 DB에 Upload하고 ExcelResult 형태로 결과를 반환해줍니다.
//        /// </summary>
//        /// <param name="table">Table 명</param>
//        /// <param name="provider">DB Provider</param>
//        /// <param name="connectionString">DB Connection String</param>
//        /// <param name="data">Data 배열</param>
//        /// <param name="legacy">Legacy DB 여부</param>
//        /// <returns>ExcelResult 값</returns>
//        public static ExcelResult AppendData(string table, string provider, string connectionString, string data, bool legacy = false, bool isDelete = false, IList wheres = null)
//        {
//            var result = new ExcelResult();

//            try
//            {
//                if (isDelete)
//                {
//                    var delete = QueryHelper.BuildDelete(table, wheres, provider, legacy);
//                    DBHelper.ExcuteNonQuery(delete, provider, connectionString);
//                }

//                var valueObj = JsonConvert.DeserializeObject<IEnumerable<Dictionary<string, object>>>(data);

//                var errorSb = new StringBuilder();
//                var cnt = 0;

//                foreach (var obj in valueObj)
//                {
//                    try
//                    {
//                        if (obj == null) throw new Exception("row obj is null!");

//                        var query = QueryHelper.BuildInsert(table, obj, provider, null, legacy);
//                        result.SuccessCount += DBHelper.ExcuteNonQuery(query, provider, connectionString);
//                    }
//                    catch (Exception ex)
//                    {
//                        result.ErrorCount++;
//                        errorSb.AppendLine();
//                        errorSb.AppendLine($"Row : {cnt}");
//                        errorSb.AppendLine();
//                        errorSb.AppendLine($"{ex.Message}\n\n{ex.StackTrace}");
//                        errorSb.AppendLine();
//                    }
//                    finally
//                    {
//                        result.TotalCount++;
//                        cnt++;
//                    }
//                }
//                result.ErrorMsg = errorSb.ToString();
//            }
//            catch (Exception e)
//            {
//                result.ErrorMsg = $"{e.Message}\n\n{e.StackTrace}";
//            }

//            return result;
//        }

//        public static ExcelResult OverwriteData(string table, string provider, string connectionString, string data, IList where = null, bool legacy = false)
//        {
//            return AppendData(table, provider, connectionString, data, legacy, true, where);
//        }

//        /// <summary>
//        /// Excel Stream을 Insert문으로 변환해줍니다.
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="stream">Excel Streme</param>
//        /// <param name="provider">DB Provider</param>
//        /// <returns></returns>
//        public static string ConvertExcelDataToQuery<T>(Stream stream, string provider)
//        {
//            string query = "";

//            IWorkbook book = new XSSFWorkbook(stream);
//            ISheet sheet = book.GetSheetAt(0);
//            for (var i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
//            {
//                IRow row = sheet.GetRow(i);
//                var item = Activator.CreateInstance<T>();
//                var flag = false;

//                for (var j = row.FirstCellNum; j < row.LastCellNum; j++)
//                {
//                    var headerCell = sheet.GetRow(sheet.FirstRowNum).GetCell(j);
//                    if (headerCell == null) continue;
//                    string header = headerCell.StringCellValue.ReplaceAll(" ", "_");
//                    ICell cell = row.GetCell(j);
//                    if (TrySetProperty(item, header, cell))
//                    {
//                        flag = true;
//                    }
//                }

//                if (flag)
//                {
//                    query += QueryHelper.BuildInsert(item.GetType().Name, item, provider) + ";";
//                }
//            }

//            return query;
//        }

//        public static NpoiMemoryStream TableToExcel(DataTable dt)
//        {
//            IWorkbook workbook = new XSSFWorkbook();
//            ISheet sheet = workbook.CreateSheet();

//            IRow row = sheet.CreateRow(0);

//            for (int i = 0; i < dt.Columns.Count; i++)
//            {
//                var col = dt.Columns[i];
//                row.CreateCell(i).SetCellValue(col.ColumnName);
//            }

//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                var data = dt.Rows[i];
//                row = sheet.CreateRow(i + 1);

//                for (int j = 0; j < dt.Columns.Count; j++)
//                {
//                    var col = dt.Columns[j];
//                    var cellValue = data[col.ColumnName];
//                    if (cellValue == DBNull.Value)
//                        continue;

//                    if (col.DataType.Name == "String")
//                    {
//                        row.CreateCell(j).SetCellValue(Convert.ToString(cellValue));
//                    }
//                    else if (col.DataType.Name == "Boolean")
//                    {
//                        row.CreateCell(j).SetCellValue(Convert.ToBoolean(cellValue));
//                    }
//                    else if (col.DataType.Name == "DateTime")
//                    {
//                        var df = workbook.CreateDataFormat();
//                        var cellStyle = workbook.CreateCellStyle();
//                        cellStyle.DataFormat = df.GetFormat("yyyy-mm-dd hh:mm:ss");
//                        var cell = row.CreateCell(j);
//                        cell.SetCellValue(Convert.ToDateTime(cellValue));
//                        cell.CellStyle = cellStyle;
//                    }
//                    else
//                    {
//                        row.CreateCell(j).SetCellValue(Convert.ToDouble(cellValue));
//                    }
//                }
//            }

//            var ms = new NpoiMemoryStream();
//            ms.AllowClose = false;
//            workbook.Write(ms);
//            ms.Flush();
//            ms.Seek(0, SeekOrigin.Begin);

//            return ms;
//        }

//        public static NpoiMemoryStream CreateGanttExcel(GanttOptions options, List<GanttRow> rows)
//        {
//            IWorkbook workbook = new XSSFWorkbook();
//            ISheet sheet = workbook.CreateSheet();

//            sheet.DefaultRowHeight = 500;

//            var startDt = rows.Min(r => r.tasks.Min(t => t.startTime));
//            var endDt = rows.Max(r => r.tasks.Max(t => t.endTime));

//            var headerInfos = DrawGanttHeader(sheet, startDt, endDt, options);
//            DrawDataHeader(sheet, options);
//            DrawDataBody(workbook, sheet, options, rows);
//            DrawGanttBody(sheet, options, rows, headerInfos);

//            var ms = new NpoiMemoryStream();
//            ms.AllowClose = false;
//            workbook.Write(ms);
//            ms.Flush();
//            ms.Seek(0, SeekOrigin.Begin);

//            return ms;
//        }

//        private static void DrawDataHeader(ISheet sheet, GanttOptions options)
//        {
//            IRow row = sheet.GetRow(0);

//            for (int i = 0; i < options.columns.Length; i++)
//            {
//                row.CreateCell(i).SetCellValue(options.columns[i]);
//                if (options.headers.Length - 1 > 0)
//                {
//                    sheet.AddMergedRegion(new CellRangeAddress(0, options.headers.Length - 1, i, i));
//                }
//            }
//        }

//        private static void DrawDataBody(IWorkbook workbook, ISheet sheet, GanttOptions options, List<GanttRow> rows)
//        {
//            var addedRowCount = 0;

//            for (int i = 0; i < rows.Count; i++)
//            {
//                var data = rows[i];
//                var firstRow = i + options.headers.Length + addedRowCount;
//                var lastRow = firstRow;
//                IRow row = sheet.CreateRow(firstRow);
//                if (data.maxLevel > 1)
//                {
//                    for (int k = 0; k < data.maxLevel - 1; k++)
//                    {
//                        addedRowCount++;
//                        lastRow = i + options.headers.Length + addedRowCount;
//                        sheet.CreateRow(lastRow);
//                    }
//                }

//                var type = data.GetType();
//                for (int j = 0; j < options.columns.Length; j++)
//                {
//                    var col = options.columns[j];
//                    var prop = type.GetProperty(col);
//                    if (prop == null) continue;

//                    if (prop.PropertyType.Name == "String")
//                    {
//                        row.CreateCell(j).SetCellValue(Convert.ToString(prop.GetValue(data)));
//                    }
//                    else if (prop.PropertyType.Name == "Boolean")
//                    {
//                        row.CreateCell(j).SetCellValue(Convert.ToBoolean(prop.GetValue(data)));
//                    }
//                    else if (prop.PropertyType.Name == "DateTime")
//                    {
//                        var df = workbook.CreateDataFormat();
//                        var cellStyle = workbook.CreateCellStyle();
//                        cellStyle.DataFormat = df.GetFormat("yyyy-mm-dd hh:mm:ss");
//                        var cell = row.CreateCell(j);
//                        cell.SetCellValue(Convert.ToDateTime(prop.GetValue(data)));
//                        cell.CellStyle = cellStyle;
//                    }
//                    else
//                    {
//                        row.CreateCell(j).SetCellValue(Convert.ToDouble(prop.GetValue(data)));
//                    }

//                    if (firstRow < lastRow)
//                    {
//                        sheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, j, j));
//                    }
//                }
//            }
//        }

//        private static GanttHeaderInfos DrawGanttHeader(ISheet sheet, DateTime startDt, DateTime endDt, GanttOptions options)
//        {
//            var result = new GanttHeaderInfos();

//            for (int i = options.headers.Length - 1; i >= 0; i--)
//            {
//                var header = options.headers[i];
//                IRow row = sheet.CreateRow(i);

//                var keyFormat = GanttHeaderKeyFormat(header.type);
//                var columns = CreateGanttColumns(header, startDt, endDt, options.widthRate, options.isFillCell, keyFormat, options.dayStartTime);

//                if (i == options.headers.Length - 1)
//                {
//                    result.KeyFormat = keyFormat;
//                    result.Headers = new Dictionary<string, GanttColumn>();
//                    result.EndHeaders = new Dictionary<string, GanttColumn>();
//                }

//                for (int j = 0; j < columns.Count; j++)
//                {
//                    var col = columns[j];
//                    if (i == options.headers.Length - 1)
//                    {
//                        var colNo = j + options.columns.Length;
//                        var cell = row.CreateCell(colNo);
//                        cell.SetCellValue(col.Text);
//                        sheet.SetColumnWidth(colNo, SizeHelper.PixelToWidthUnits((int)col.Width));
//                        col.ColNo = colNo;
//                        result.Headers[col.Key] = col;
//                        result.EndHeaders[col.EndKey] = col;
//                    }
//                    else
//                    {
//                        if (result.Headers.TryGetValue(col.From.ToString(result.KeyFormat), out GanttColumn fromCol))
//                        {
//                            if (result.EndHeaders.TryGetValue(col.To.ToString(result.KeyFormat), out GanttColumn toCol))
//                            {
//                                var cell = row.CreateCell(fromCol.ColNo);
//                                cell.SetCellValue(col.Text);
//                                if (fromCol.ColNo < toCol.ColNo)
//                                {
//                                    sheet.AddMergedRegion(new CellRangeAddress(i, i, fromCol.ColNo, toCol.ColNo));
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            return result;
//        }

//        private static void DrawGanttBody(ISheet sheet, GanttOptions options, List<GanttRow> rows, GanttHeaderInfos headerInfos)
//        {
//            var drawing = sheet.CreateDrawingPatriarch() as XSSFDrawing;
//            var colorGen = new ColorGenerator();
//            var addedRowCount = 0;

//            for (int i = 0; i < rows.Count; i++)
//            {
//                var data = rows[i];
//                var rowNo = i + options.headers.Length + addedRowCount;
//                addedRowCount += data.maxLevel - 1;

//                foreach (var task in data.tasks)
//                {
//                    var levelRowNo = rowNo + task.level - 1;
//                    if (headerInfos.Headers.TryGetValue(task.startTime.ToString(headerInfos.KeyFormat), out GanttColumn fromCol))
//                    {
//                        var endDic = options.isFillCell ? headerInfos.EndHeaders : headerInfos.Headers;
//                        if (endDic.TryGetValue(task.endTime.ToString(headerInfos.KeyFormat), out GanttColumn toCol))
//                        {
//                            var color = string.IsNullOrWhiteSpace(task.backgroundColor) ?
//                                colorGen.GetColor(task.key) : colorGen.HexToColor(task.backgroundColor);
//                            var borderColor = string.IsNullOrWhiteSpace(task.borderColor) ?
//                                colorGen.ChangeColorBrightness(color, -0.2f) : colorGen.HexToColor(task.borderColor);

//                            if (options.isFillCell)
//                            {
//                                var row = sheet.GetRow(levelRowNo);
//                                var endCol = task.endTime > toCol.To ? toCol.ColNo + 1 : toCol.ColNo;
//                                for (int j = fromCol.ColNo; j <= endCol; j++)
//                                {
//                                    var cell = row.CreateCell(j);
//                                    if (j == fromCol.ColNo)
//                                    {
//                                        cell.SetCellValue(task.text);
//                                    }
//                                    var cellStyle = (XSSFCellStyle)sheet.Workbook.CreateCellStyle();
//                                    var colorToFill = new XSSFColor(color);
//                                    cellStyle.SetFillForegroundColor(colorToFill);
//                                    cellStyle.FillPattern = FillPattern.SolidForeground;
//                                    cell.CellStyle = cellStyle;
//                                }
//                            }
//                            else
//                            {
//                                var fromWidth = SizeHelper.DateRangeToWidth(fromCol.From, task.startTime, options.widthRate);
//                                var toWidth = SizeHelper.DateRangeToWidth(task.endTime, toCol.To, options.widthRate);
//                                var anchor = new XSSFClientAnchor(
//                                    (int)(fromWidth * XSSFShape.EMU_PER_PIXEL),
//                                    2 * XSSFShape.EMU_PER_PIXEL,
//                                    (int)-(toWidth * XSSFShape.EMU_PER_PIXEL),
//                                    -2 * XSSFShape.EMU_PER_PIXEL,
//                                    fromCol.ColNo, levelRowNo, toCol.ColNo + 1, levelRowNo + 1);
//                                //anchor.AnchorType = AnchorType.DontMoveAndResize;
//                                XSSFSimpleShape shape = drawing.CreateSimpleShape(anchor);
//                                shape.SetText(new XSSFRichTextString(task.text));
//                                shape.SetFillColor(color.R, color.G, color.B);
//                                shape.SetLineStyleColor(borderColor.R, borderColor.G, borderColor.B);
//                            }
//                        }
//                    }
//                }
//            }
//        }

//        private static DateTime SetNextDt(string type, DateTime dt, int dayStartTime)
//        {
//            switch (type)
//            {
//                case "Year":
//                    return dt.StartOfYear().AddYears(1).AddHours(dayStartTime);
//                case "Month":
//                    return dt.StartOfMonth().AddMonths(1).AddHours(dayStartTime);
//                case "Week":
//                    return dt.StartOfWeek().AddDays(7).AddHours(dayStartTime);
//                case "Day":
//                    return dt.StartOfDay().AddDays(1).AddHours(dayStartTime);
//                case "Hour":
//                    return dt.StartOfHour().AddHours(1);
//                case "Minute":
//                    return dt.StartOfMinute().AddMinutes(1);
//            }
//            return dt;
//        }

//        private static string GetGanttHeaderText(GanttHeader header, DateTime dt)
//        {
//            if (!string.IsNullOrWhiteSpace(header.format))
//            {
//                return dt.ToString(header.format);
//            }

//            switch (header.type)
//            {
//                case "Year":
//                    return dt.ToString("yyyy");
//                case "Month":
//                    return dt.ToString("MM");
//                case "Week":
//                    return dt.ToString("ddd");
//                case "Day":
//                    return dt.ToString("dd");
//                case "Hour":
//                    return dt.ToString("HH");
//                case "Minute":
//                    return dt.ToString("mm");
//            }
//            return string.Empty;
//        }

//        private static string GanttHeaderKeyFormat(string type)
//        {
//            switch (type)
//            {
//                case "Year":
//                    return "yyyy";
//                case "Month":
//                    return "yyyyMM";
//                case "Week":
//                case "Day":
//                    return "yyyyMMdd";
//                case "Hour":
//                    return "yyyyMMddHH";
//                case "Minute":
//                    return "yyyyMMddHHmm";
//            }
//            return string.Empty;
//        }

//        private static List<GanttColumn> CreateGanttColumns(GanttHeader header, DateTime startDt, DateTime endDt, double widthRate, bool isFillCell, string keyFormat, int dayStartTime)
//        {
//            var result = new List<GanttColumn>();

//            var next = startDt.Copy();
//            var prev = startDt.Copy();

//            do
//            {
//                next = SetNextDt(header.type, next, dayStartTime);
//                var minDate = prev;
//                var maxDate = endDt > next || isFillCell ? next : endDt;
//                var text = GetGanttHeaderText(header, prev);
//                result.Add(new GanttColumn
//                {
//                    Key = minDate.ToString(keyFormat),
//                    EndKey = maxDate.ToString(keyFormat),
//                    Text = text,
//                    Width = SizeHelper.DateRangeToWidth(minDate, maxDate, widthRate),
//                    From = minDate,
//                    To = maxDate,
//                });
//                prev = SetNextDt(header.type, prev, dayStartTime);
//            } while (endDt > prev);

//            return result;
//        }

//        private static Type GetValueType(ICell value)
//        {
//            if (value.CellType == CellType.Numeric)
//            {
//                if (DateUtil.IsCellDateFormatted(value))
//                {
//                    return typeof(DateTime);
//                }
//                else
//                {
//                    return typeof(double);
//                }
//            }
//            else if (value.CellType == CellType.Boolean)
//            {
//                return typeof(bool);
//            }
//            else
//            {
//                return typeof(string);
//            }
//        }

//        private static bool TryGetCellValue(Type type, ICell value, out object obj)
//        {
//            if (type == typeof(double) ||
//                type == typeof(int) ||
//                type == typeof(Int64) ||
//                type == typeof(float) ||
//                type == typeof(long) ||
//                type == typeof(decimal))
//            {
//                obj = value == null || value.CellType == CellType.Blank ? 0 : value.NumericCellValue;
//                if (value == null) return false;
//            }
//            else if (type == typeof(bool))
//            {
//                obj = value == null || value.CellType == CellType.Blank ? false : value.BooleanCellValue;
//            }
//            else if (type == typeof(DateTime))
//            {
//                obj = value == null || value.CellType == CellType.Blank ? DateTime.MinValue : value.CellType ==
//                    CellType.String ? Convert.ToDateTime(value.StringCellValue) : value.DateCellValue;
//            }
//            else
//            {
//                if (value == null)
//                {
//                    obj = null;
//                    return false;
//                }
//                else if (value.CellType == CellType.Boolean)
//                {
//                    obj = value.BooleanCellValue.ToString().ToLower();
//                }
//                else if (value.CellType == CellType.Numeric)
//                {
//                    obj = value.DateCellValue.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
//                }
//                else
//                {
//                    obj = value == null || value.CellType == CellType.Blank ? null : value.StringCellValue;
//                }
//            }
//            return value.CellType != CellType.Blank;
//        }

//        private static bool TrySetProperty(object obj, string property, ICell value)
//        {
//            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
//            if (prop != null && prop.CanWrite)
//            {
//                if (value == null) return false;
//                if (value.CellType == CellType.Blank) return false;

//                if (value.CellType == CellType.String)
//                {
//                    SetValue(prop, obj, value.StringCellValue);
//                }
//                else if (value.CellType == CellType.Numeric)
//                {
//                    SetValue(prop, obj, value.NumericCellValue);
//                }
//                else if (value.CellType == CellType.Boolean)
//                {
//                    SetValue(prop, obj, value.BooleanCellValue);
//                }

//                return true;
//            }
//            return false;
//        }

//        private static void SetValue(PropertyInfo prop, object obj, object value)
//        {
//            var v = value.ToString();

//            if (prop.PropertyType == typeof(string))
//            {
//                prop.SetValue(obj, v, null);
//            }
//            else if (prop.PropertyType == typeof(int))
//            {
//                prop.SetValue(obj, int.Parse(v), null);
//            }
//            else if (prop.PropertyType == typeof(DateTime))
//            {
//                prop.SetValue(obj, DateTime.Parse(v), null);
//            }
//            else if (prop.PropertyType == typeof(Nullable<DateTime>))
//            {
//                prop.SetValue(obj, DateTime.Parse(v), null);
//            }
//            else if (prop.PropertyType == typeof(double))
//            {
//                prop.SetValue(obj, double.Parse(v), null);
//            }
//            else if (prop.PropertyType == typeof(bool))
//            {
//                prop.SetValue(obj, bool.Parse(v), null);
//            }
//        }

//        private static int FindHeaderLineIndex(DataTable schemaDt, string[] dataList)
//        {
//            int length = Math.Min(1000, dataList.Length);

//            for (int i = 0; i < length; i++)
//            {
//                string data = dataList[i];
//                string[] datas = data.Split('\t');

//                foreach (string value in datas)
//                {
//                    if (schemaDt.Columns.Contains(value))
//                        return i;
//                }
//            }

//            return -1;
//        }

//        public static DataColumn[] GetColumns(DataTable schemaDt, string data)
//        {
//            string[] names = data.Split('\t');
//            int count = names.Length;

//            for (int i = 0; i < count; i++)
//                names[i] = names[i].Trim();

//            var columns = new DataColumn[count];
//            for (int i = 0; i < count; i++)
//            {
//                if (string.IsNullOrEmpty(names[i]))
//                    continue;

//                columns[i] = schemaDt.Columns[names[i]];

//                if (columns[i] == null)
//                {
//                    columns[i] = schemaDt.Columns.OfType<DataColumn>()
//                        .FirstOrDefault(f => !string.IsNullOrEmpty(f.Caption) && f.Caption == names[i]);
//                }
//            }

//            return columns;
//        }

//        private static object ConvertType(object value, Type typeofReturn, object defaultValue)
//        {
//            if (value != null && value != DBNull.Value && string.IsNullOrEmpty(value.ToString()) == false)
//            {
//                object changedValue = null;
//                IConvertible convertible = value as IConvertible;
//                if (convertible != null)
//                {
//                    if (typeofReturn == typeof(int))
//                        changedValue = Int32.Parse(value.ToString(), System.Globalization.NumberStyles.AllowThousands);
//                    else if (typeofReturn == typeof(bool))
//                        changedValue = ConvertStringToBool(value, typeofReturn);
//                    else
//                        changedValue = Convert.ChangeType(value, typeofReturn);
//                }
//                else
//                {
//                    TypeConverter converter = TypeDescriptor.GetConverter(typeofReturn);
//                    if (converter != null && converter.CanConvertFrom(value.GetType()))
//                        changedValue = converter.ConvertFrom(value);

//                    else if (value.GetType() == typeof(string))
//                    {
//                        if (typeofReturn == typeof(Enum))
//                            changedValue = Enum.Parse(typeofReturn, (string)value, true);

//                        else
//                        {
//                            MethodInfo parse = typeofReturn.GetMethod("Parse", new Type[] { typeof(string) });
//                            if (parse != null)
//                                changedValue = parse.Invoke(null, new object[] { value });
//                        }
//                    }
//                }

//                if (changedValue != null)
//                {
//                    return changedValue;
//                }

//            }

//            return defaultValue;
//        }

//        private static object ConvertStringToBool(object value, Type typeofReturn)
//        {
//            string str = value.ToString();
//            if (str == "Checked")
//                value = true;
//            else if (str == "Unchecked")
//                value = false;

//            return Convert.ChangeType(value, typeofReturn);
//        }
//    }
//}
