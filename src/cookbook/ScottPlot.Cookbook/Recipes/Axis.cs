﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ScottPlot.Cookbook.Recipes.Ticks
{
    class AxisLabel : IRecipe
    {
        public string Category => "Axis and Ticks";
        public string ID => "Axis_label";
        public string Title => "Axis Customizations";
        public string Description => "Axes can be customized different ways. " +
            "Axis labels and colors are the most common types of customizations.";

        public void ExecuteRecipe(Plot plt)
        {
            // plot sample data
            plt.AddSignal(DataGen.Sin(51));
            plt.AddSignal(DataGen.Cos(51));

            // This is the simplest way to give an axis a label
            plt.XLabel("Horizontal Axis");

            // Axes can be addressed individually, giving the user access to more options
            plt.XAxis.SetLabel("Horizontal Axis");
            plt.XAxis.SetColor(Color.Green);

            // Many customizations are available through public methods
            plt.YAxis.SetLabel(label: "Vertical Axis", color: Color.Magenta, size: 24, fontName: "Comic Sans MS");
        }
    }

    class GridDisable : IRecipe
    {
        public string Category => "Axis and Ticks";
        public string ID => "axis_gridDisableAll";
        public string Title => "Disable Grid";
        public string Description => "Visibility of primary X and Y grids can be set using a single method.";

        public void ExecuteRecipe(Plot plt)
        {
            // plot sample data
            plt.AddSignal(DataGen.Sin(51));
            plt.AddSignal(DataGen.Cos(51));

            // hide grids
            plt.Grid(false);
        }
    }

    class GridOne : IRecipe
    {
        public string Category => "Axis and Ticks";
        public string ID => "axis_gridDisableOne";
        public string Title => "Disable Vertical Grid";
        public string Description =>
            "Grid line visibility can be controlled for each axis individually. " +
            "Use this to selectively enable grid lines only for the axes of interest. " +
            "Keep in mind that vertical grid lines are controlled by horizontal axes.";

        public void ExecuteRecipe(Plot plt)
        {
            // plot sample data
            plt.AddSignal(DataGen.Sin(51));
            plt.AddSignal(DataGen.Cos(51));

            // control grid visibility by axis
            plt.XAxis.Grid(false);
            plt.YAxis.Grid(true);
        }
    }

    class GridConfigure : IRecipe
    {
        public string Category => "Axis and Ticks";
        public string ID => "asis_gridConfigure";
        public string Title => "Grid Style";
        public string Description => "Common grid line configurations are available.";

        public void ExecuteRecipe(Plot plt)
        {
            // plot sample data
            plt.AddSignal(DataGen.Sin(51));
            plt.AddSignal(DataGen.Cos(51));

            // common grid customizations are color and style
            plt.GridColor(Color.FromArgb(50, Color.Green));
            plt.GridLineStyle(LineStyle.Dot);
        }
    }

    class TicksHideX : IRecipe
    {
        public string Category => "Axis and Ticks";
        public string ID => "ticks_hidex";
        public string Title => "Disable X Ticks";
        public string Description => "Ticks can be hidden on a single axis.";

        public void ExecuteRecipe(Plot plt)
        {
            // plot sample data
            plt.AddSignal(DataGen.Sin(51));
            plt.AddSignal(DataGen.Cos(51));

            // hide just the horizontal axis ticks
            plt.XAxis.Configure(ticks: false);
        }
    }

    class TicksRotated : IRecipe
    {
        public string Category => "Axis and Ticks";
        public string ID => "ticks_rotated";
        public string Title => "Rotated Ticks";
        public string Description => "Tick labels can be rotated as desired.";

        public void ExecuteRecipe(Plot plt)
        {
            // plot sample data
            plt.AddSignal(DataGen.Sin(51));
            plt.AddSignal(DataGen.Cos(51));

            // rotate horizontal axis tick labels
            plt.XAxis.TickLabelStyle(rotation: 45);
        }
    }

    class TicksDateTime : IRecipe
    {
        public string Category => "Axis and Ticks";
        public string ID => "ticks_dateTime";
        public string Title => "Plotting DateTime Data";
        public string Description =>
            "This example shows how to display DateTime data on the horizontal axis. " +
            "Use DateTime.ToOADate() to convert DateTime[] to double[], plot the data, " +
            " then tell the axis to format tick labels as dates.";

        public void ExecuteRecipe(Plot plt)
        {
            // create data sample data
            DateTime[] myDates = new DateTime[100];
            for (int i = 0; i < myDates.Length; i++)
                myDates[i] = new DateTime(1985, 9, 24).AddDays(7 * i);

            // Convert DateTime[] to double[] before plotting
            double[] xs = myDates.Select(x => x.ToOADate()).ToArray();
            double[] ys = DataGen.RandomWalk(myDates.Length);
            plt.AddScatter(xs, ys);

            // Then tell the axis to display tick labels using a time format
            plt.XAxis.DateTimeFormat(true);
        }
    }
}