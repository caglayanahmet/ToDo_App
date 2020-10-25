// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';


// Pie Chart Example
var ctx = document.getElementById("myPieChart");
var dotnet = $("#dotnetcompletion").text();
var typing = $('#typingCompletion').text();
var javaScript = $('#javascriptCompletion').text();
var daily = $('#dailystuffCompletion').text();
var wordpress = $('#wordpressCompletion').text();

var myPieChart = new Chart(ctx, {
  type: 'doughnut',
  data: {
    labels: ["wordpress", ".Net", "Typing","Daily Stuff", "JavaScript"],
    datasets: [{
        data: [wordpress, dotnet, typing,daily,javaScript],
      backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc','#121212','#232323'],
      hoverBackgroundColor: ['#2e59d9', '#17a673', '#2c9faf'],
      hoverBorderColor: "rgba(234, 236, 244, 1)",
    }],
  },
  options: {
    maintainAspectRatio: false,
    tooltips: {
      backgroundColor: "rgb(255,255,255)",
      bodyFontColor: "#858796",
      borderColor: '#dddfeb',
      borderWidth: 1,
      xPadding: 15,
      yPadding: 15,
      displayColors: false,
      caretPadding: 10,
    },
    legend: {
      display: false
    },
    cutoutPercentage: 80,
  },
});
