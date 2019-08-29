using System;
using System.Collections.Generic;
using System.Linq;

namespace webAppNotebook
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Backend code for the Interface. This code makes 
            string total = "total";
            //Converts the crime data into a list with the format of the totalCrimeYear class
            List<crimeclass.totalCrimeYear> crime = crimeAmount.GetCrimeCount(total);
            titleLabel.Text = "Most commited crimes since 2015";
            Chart1.Series.Add("crime");
            //Adds each row of the list to the graoh
            foreach (var values in crime)
            {
                Chart1.Width = 1000;
                Chart1.ChartAreas.FirstOrDefault().AxisX.Interval = 1;
                Chart1.Series["crime"].Points.AddXY(xValue: values.crime, yValue: values.count);
            }
            //Converts the data from the request to a list
            List<crimeclass.crimebyYear> assault = crimeAmount.assaultChart();
            List<crimeclass.crimebyYear> theft = crimeAmount.theftChart();
            List<crimeclass.crimebyYear> narcotics = crimeAmount.narcoticsChart();
            Chart2.Series.Add("assault");
            //Sets the type of graph as line
            Chart2.Series["assault"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            Chart2.Series.Add("theft");
            Chart2.Series["theft"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            Chart2.Series.Add("narcotics");
            Chart2.Series["narcotics"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            Chart2.Legends.Add("Crime Type");
            Chart2.Width = 1000;
            Chart2.ChartAreas.FirstOrDefault().AxisX.Interval = 1;
            foreach (var numbers in assault)
            {
                Chart2.Series["assault"].Points.AddXY(xValue: numbers.Year, yValue: numbers.count);
            }            
            Chart2.Series.Add("theft");
            Chart2.Series["theft"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            foreach (var numbers in theft)
            {
                Chart2.Series["theft"].Points.AddXY(xValue: numbers.Year, yValue: numbers.count);
            }
            
            
            foreach (var numbers in narcotics)
            {
                Chart2.Series["narcotics"].Points.AddXY(xValue: numbers.Year, yValue: numbers.count);
            }

            List<crimeclass.crimesbyDistrict> district = crimeAmount.districtChart();
            Chart3.Series.Add("district");
            Chart3.Width = 1000;
            Chart3.Series["district"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            Chart3.ChartAreas["ChartArea1"].AxisX.Maximum = 25;
            Chart3.ChartAreas["ChartArea1"].AxisX.Minimum = 1;
            foreach (var d in district)
            {
                    Chart3.ChartAreas.FirstOrDefault().AxisX.Interval = 1;
                    Chart3.Series["district"].Points.AddXY(xValue: d.district, yValue: d.count);
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            bool validation = crimeAmount.validate(textBox.Text);
            if (validation == true)
            {
                string year = textBox.Text;
                List<crimeclass.totalCrimeYear> crime = crimeAmount.GetCrimeCount(year);
                titleLabel.Text = "Most commited crimes in " + textBox.Text;
                Chart1.Series.Clear();
                Chart1.Series.Add("crime");
                foreach (var values in crime)
                {
                    Chart1.Width = 1000;
                    Chart1.ChartAreas.FirstOrDefault().AxisX.Interval = 1;
                    Chart1.Series["crime"].Points.AddXY(xValue: values.crime, yValue: values.count);
                }
            }
            else
                label1.Text = "Please Enter Correct Year";
        }


    }
    
}