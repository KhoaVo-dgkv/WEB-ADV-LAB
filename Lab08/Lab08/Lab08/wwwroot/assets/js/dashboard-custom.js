$(function () {
  // -----------------------------------------------------------------------
  // Cars Overview Chart - using data from server
  // -----------------------------------------------------------------------

  // Get data from global variable set in the view
  var brandNames = [];
  var carCounts = [];

  if (typeof brandCarData !== 'undefined' && brandCarData.length > 0) {
    brandCarData.forEach(function(item) {
      brandNames.push(item.brand);
      carCounts.push(item.count);
    });
  } else {
    // Fallback if no data
    brandNames = ['No Data'];
    carCounts = [0];
  }

  // Calculate max value for y-axis
  var maxCount = Math.max(...carCounts, 1);
  var yAxisMax = Math.ceil(maxCount * 1.2);

  var options_sales_overview = {
    series: [
      {
        name: "Cars",
        data: carCounts,
      },
    ],
    chart: {
      type: "bar",
      height: 275,
      toolbar: {
        show: false,
      },
      foreColor: "#adb0bb",
      fontFamily: "inherit",
      sparkline: {
        enabled: false,
      },
    },
    grid: {
      show: false,
      borderColor: "transparent",
      padding: {
        left: 0,
        right: 0,
        bottom: 0,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "25%",
        endingShape: "rounded",
        borderRadius: 5,
      },
    },
    colors: ["var(--bs-primary)"],
    dataLabels: {
      enabled: false,
    },
    yaxis: {
      show: true,
      min: 0,
      max: yAxisMax,
      tickAmount: 4,
    },
    stroke: {
      show: true,
      width: 5,
      lineCap: "butt",
      colors: ["transparent"],
    },
    xaxis: {
      type: "category",
      categories: brandNames,
      axisBorder: {
        show: false,
      },
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
    },
    legend: {
      show: false,
    },
  };

  var chart_column_basic = new ApexCharts(
    document.querySelector("#sales-overview"),
    options_sales_overview
  );
  chart_column_basic.render();
});

