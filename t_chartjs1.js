$(function () {
    new Chart(document.getElementById("line_chart").getContext("2d"), getChartJs('line'));
    new Chart(document.getElementById("bar_chart").getContext("2d"), getChartJs('bar'));
    new Chart(document.getElementById("radar_chart").getContext("2d"), getChartJs('radar'));
    new Chart(document.getElementById("pie_chart").getContext("2d"), getChartJs('pie'));
    new Chart(document.getElementById("donut_chart").getContext("2d"), getChartJs('doughnut'));
    new Chart(document.getElementById("h_bar_chart").getContext("2d"), getChartJs('bar'));
});

function getChartJs(type) {
    var config = null;
    // for bar chart dynamic data
    var labelName = $('#HAgeMale').val();
    var array = labelName.split(",");
    var one = array[0];
    var Two = array[1];
    var Three = array[2];
    var Four = array[3];
    var Five = array[4];

    var labelName1 = $('#HEmpGender').val();
    var array1 = labelName1.split(",");
    var one1 = array1[0];
    var Two1 = array1[1];
    var Three1 = array1[2];
    var Four1 = array1[3];
    var Five1 = array1[4];

    //for line chart dynamic data
    var lbl_dpt = $('#h_dept').val();
    var ar_dept = lbl_dpt.split(",");
    var d1 = ar_dept[0];
    var d2 = ar_dept[1];
    var d3 = ar_dept[2];
    var d4 = ar_dept[3];
    var d5 = ar_dept[4];
    var d6 = ar_dept[5];
    var d7 = ar_dept[6];
    var lbl_maleCount = $('#h_male_count').val();
    var ar_maleCount = lbl_maleCount.split(",");
    var m1 = ar_maleCount[0];
    var m2 = ar_maleCount[1];
    var m3 = ar_maleCount[2];
    var m4 = ar_maleCount[3];
    var m5 = ar_maleCount[4];
    var m6 = ar_maleCount[5];
    var m7 = ar_maleCount[6];
    var lbl_femaleCount = $('#h_female_count').val();
    var ar_femaleCount = lbl_femaleCount.split(",");
    var f1 = ar_femaleCount[0];
    var f2 = ar_femaleCount[1];
    var f3 = ar_femaleCount[2];
    var f4 = ar_femaleCount[3];
    var f5 = ar_femaleCount[4];
    var f6 = ar_femaleCount[5];
    var f7 = ar_femaleCount[6];


    //for dynamic data pie chart
    var lbl_v_status = $('#h_v_status').val();
    var ar_v_status = lbl_v_status.split(",");
    var vs1 = ar_v_status[0];
    var vs2 = ar_v_status[1];
    var vs3 = ar_v_status[2];

    var lbl_v_count = $('#h_v_count').val();
    var ar_v_count = lbl_v_count.split(",");
    var vc1 = ar_v_count[0];
    var vc2 = ar_v_count[1];
    var vc3 = ar_v_count[2];


    if (type === 'line') {
        config = {
            type: 'line',
            data: {
                //labels: ["HR", "Account",
                data: {
                    //labels: ["HR", "Account", "Finance", "Sales", "Marketing", "Development", "Support"],
                    //labels: ["HR", "A/C_Finance", "IT", "Operations", "Marketing", "Sales", "Support"],
                    labels: [d1, d2, d3, d4, d5, d6, d7],
                    datasets: [{
                        label: "Male",
                       /* data: [65, 59, 80, 81, 56, 55, 40],*/
                        data: [m1, m2, m3, m4, m5, m6, m7],
                        borderColor: 'rgba(0, 188, 212, 0.75)',
                        backgroundColor: 'rgba(0, 188, 212, 0.3)',
                        pointBorderColor: 'rgba(0, 188, 212, 0)',
                        pointBackgroundColor: 'rgba(0, 188, 212, 0.9)',
                        pointBorderWidth: 1
                    }, {
                        label: "Female",
                        data: data: [f1, f2, f3, f4, f5, f6, f7],
                        borderColor: 'rgba(233, 30, 99, 0.75)',
                        backgroundColor: 'rgba(233, 30, 99, 0.3)',
                        pointBorderColor: 'rgba(233, 30, 99, 0)',
                        pointBackgroundColor: 'rgba(233, 30, 99, 0.9)',
                        pointBorderWidth: 1
                    }]
                },
                //options: {
                //    responsive: true,
                //    legend: false
                //}
                options: {
                    plugins: {
                        datalabels: {
                            display: true,
                            align: 'bottom',
                            backgroundColor: '#ccc',
                            responsive: true,
                            legend: true,
                            font: {
                                size: 18,
                            }
                        },
                    }
                }
            }
        }
    }
    else if (type === 'bar') {

        config = {
            type: 'bar',
            data: {
                labels: ["18-25", "26-35", "36-45", "46-60", "60+"],
                datasets: [{
                    label: "Male",
                    data: [one1, Two1, Three1, Four1, Five1],
                    backgroundColor: 'rgba(0, 188, 212, 0.8)'
                }, {
                    label: "Female",
                    data: [one, Two, Three, Four, Five],
                    backgroundColor: 'rgba(233, 30, 99, 0.8)'
                }]
            },
            //options: {
            //    responsive: true,
            //    legend: false
            //}
            options: {
                plugins: {
                    datalabels: {
                        display: true,
                        align: 'bottom',
                        backgroundColor: '#ccc',
                        font: {
                            size: 18,
                        }
                    },
                }
            }
        }
    }


    else if (type === 'radar') {
        config = {
            type: 'radar',
            data: {
                labels: ["A+", "A-", "B+", "B-", "O+", "O-", "AB+"],
                datasets: [{
                    label: "Male",
                    data: [65, 25, 90, 81, 56, 55, 40],
                    borderColor: 'rgba(0, 188, 212, 0.8)',
                    backgroundColor: 'rgba(0, 188, 212, 0.5)',
                    pointBorderColor: 'rgba(0, 188, 212, 0)',
                    pointBackgroundColor: 'rgba(0, 188, 212, 0.8)',
                    pointBorderWidth: 1
                }, {
                    label: "Female",
                    data: [72, 48, 40, 19, 96, 27, 100],
                    borderColor: 'rgba(233, 30, 99, 0.8)',
                    backgroundColor: 'rgba(233, 30, 99, 0.5)',
                    pointBorderColor: 'rgba(233, 30, 99, 0)',
                    pointBackgroundColor: 'rgba(233, 30, 99, 0.8)',
                    pointBorderWidth: 1
                }]
            },
            options: {
                responsive: true,
                legend: true
            }
        }
    }
    else if (type === 'pie') {
        config = {
            type: 'pie',
            data: {                
                datasets: [{
                    data: [vc1, vc2, vc3],
                    backgroundColor: [
                        "rgb(233, 30, 99)",
                        "rgb(255, 193, 7)",
                        "rgb(0, 188, 212)",
                        "rgb(139, 195, 74)"
                    ],
                }],
                labels: [
                    "Fully Vaccinated",
                    "Not Vaccinated",
                    "Partially Vaccinated"
                ],
            },
        
            options: {
                plugins: {
                    datalabels: {
                        display: true,
                        align: 'bottom',
                        backgroundColor: '#ccc',                         
                        font: {
                            size: 18,
                        }
                    },
                }
            }
        }
    }
  
    else if(type === 'doughnut') {
        config = {
            type: 'doughnut',
            data: {
                datasets: [
                    {
                        data: [25, 20, 15, 10, 30],
                        backgroundColor: ['rgb(255, 99, 132)',
                            'rgb(255, 159, 64)',
                            'rgb(255, 205, 86)',
                            'rgb(75, 192, 192)',
                            'rgb(54, 162, 235)',],
                    },
                ],
                labels: ['Blood Pressure', 'Diabetes', 'Heart Ailmet', 'Hypertension', 'Overweight and Obesity'],
            },
            options: {
                plugins: {
                    datalabels: {
                        formatter: (value) => {
                            return value + '%';
                        }
                    }
                }
            }
        }


    }

    else if (type == 'bar_h') {

        const config = {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [
                    {
                        label: 'male',
                        data: [68, 22, 24, 30, 32],
                        backgroundColor: 'rgba(0, 188, 212, 0.8)'

                    },
                    {
                        label: 'female',
                        data: [20, 28, 56, 45, 20],
                        backgroundColor: 'rgba(233, 30, 99, 0.8)'
                    }
                ]
            },
            options: {
                indexAxis: 'y',
                // Elements options apply to all of the options unless overridden in a dataset
                // In this case, we are setting the border of each horizontal bar to be 2px wide
                elements: {
                    bar: {
                        borderWidth: 2,
                    }
                },
                responsive: true,
                plugins: {
                    legend: {
                        position: 'right',
                    },
                    title: {
                        display: true,
                        text: 'Chart.js Horizontal Bar Chart'
                    }
                }
            },
        };


    }

    return config;
}
/*donut chart for top vulnerebilities*/
var ctx = document.getElementById("headCountPieChart");
var labelName = $('#HDepartmentName').val();
var array = labelName.split(",");
var one = array[0];
var Two = array[1];
var Three = array[2];
var Four = array[3];
var Five = array[4];


var testCount = $('#HDepartmentCount').val();
var array1 = testCount.split(",");
var one1 = array1[0];
var Two1 = array1[1];
var Three1 = array1[2];
var Four1 = array1[3];
var Five1 = array1[4];
var testTotalCount = $('#HDepartmentTotal').val();
var headCountPieChart = new Chart(ctx,
    {
        type: 'doughnut',

        data: {
            labels: [one, Two, Three, Four, Five],
            datasets: [{
            backgroundColor: ["rgb(255, 99, 132)", "rgb(255, 159, 64)", "rgb(255, 205, 86)", "rgb(75, 192, 192)", "rgb(54, 162, 235)"],
                
                hoverBackgroundColor: ["rgb(255, 99, 132)", "rgb(255, 159, 64)", "rgb(255, 205, 86)", "rgb(75, 192, 192)", "rgb(54, 162, 235)"],

                // borderColor: "#4e73df",
                data: [one1, Two1, Three1, Four1, Five1],
            }],
        },

        options: {
            maintainAspectRatio: false,
            plugins: {
                labels: {
                    render: 'percentage',
                    fontColor: '#fff',
                    precision: 2,
                    fontSize: 10
                }
            },

            legend: {
                display: true
            },
            cutoutpercentage: 20
        }
    });

/*pie chart for covid test */
var ctx = document.getElementById("testCountPieChart");
var labelName = $('#HAgegroupAmt').val();
var array = labelName.split(",");
var one = array[0];
var Two = array[1];
var Three = array[2];

var testCountPieChart = new Chart(ctx, {
    type: 'pie',
    data: {
        labels: ["Fully Vaccinated", "Not Vaccinated", "Partially Vaccinated"],
        datasets: [{

           
            //backgroundColor: ["#3b00ed", "#18acf6", "#8e08a5"],
            backgroundColor: ["rgb(233, 30, 99)", "rgb(255, 193, 7)", "rgb(0, 188, 212)"],

            hoverBackgroundColor: ["rgb(233, 30, 99)", "rgb(255, 193, 7)", "rgb(0, 188, 212)"],
            // borderColor: "#4e73df",
            data: [one, Two, Three],
        }],
    },
    options: {
        maintainAspectRatio: false,
        plugins: {
            labels: {
                render: 'percentage',
                fontColor: '#fff',
                precision: 2,
                fontSize: 10
            }
        },

        legend: {
            display: true,
            position: 'bottom'
        },
    }
});

/*bar chart for Employee age ratio */
//var ctx = document.getElementById("empCountPieChart");
//var labelName = $('#HAgeMale').val();
//var array = labelName.split(",");
//var one = array[0];
//var Two = array[1];
//var Three = array[2];
//var Four = array[3];
//var Five = array[4];

//var labelName1 = $('#HAgeFemale').val();
//var array1 = labelName1.split(",");
//var one1 = array1[0];
//var Two1 = array1[1];
//var Three1 = array1[2];
//var Four1 = array1[3];
//var Five1 = array1[4];

//var labelName2 = $('#HEmpGender').val();
//var array2 = labelName2.split(",");
//var one2 = array2[0];
//var Two2 = array2[1];

//var empCountPieChart = new Chart(ctx, {
//    type: 'bar',
//  /*  data: {*/
//        //labels: ["18-25", "26-35", "36-45", "46-60", "60+"],
//        //datasets: [{


//            //backgroundColor: ["#3b00ed", "#18acf6", "#8e08a5"],
//            backgroundColor: ["rgb(233, 30, 99)", "rgb(255, 193, 7)", "rgb(0, 188, 212)"],

//            hoverBackgroundColor: ["#2e59d9", "#457dcc", "#cc6601"],
//            // borderColor: "#4e73df",
           

//            data: {
//                labels: ["18-25", "26-35", "36-45", "46-60", "60+"],
//                datasets: [{
//                    label: one2,
//                    data: [one, Two, Three, Four, Five],
//                    backgroundColor: 'rgba(0, 188, 212, 0.8)'
//                }, {
//                    label: Two2,
//                    data: [one1, Two1, Three1, Four1, Five1],
//                    backgroundColor: 'rgba(233, 30, 99, 0.8)'
//                }],
//      /*  }],*/
//   /* },*/
//    options: {
//        maintainAspectRatio: false,
//        plugins: {
//            labels: {
//                render: 'percentage',
//                fontColor: '#fff',
//                precision: 2,
//                fontSize: 10
//            }
//        },

//        legend: {
//            display: true,
//            position: 'bottom'
//        },
//    }
//});

/*donut chart for emp health*/
var ctx = document.getElementById("healthCountPieChart");
var labelName = $('#HhealthName').val();
var array = labelName.split(",");
var one = array[0];
var Two = array[1];



var testCount = $('#HhealthCount').val();
var array1 = testCount.split(",");
var one1 = array1[0];
var Two1 = array1[1];

var testTotalCount = $('#HhealthTotal').val();
var healthCountPieChart = new Chart(ctx,
    {
        type: 'doughnut',

        data: {
            labels: [one, Two],
            datasets: [{
                backgroundColor: ["rgb(255, 99, 132)",  "rgb(54, 162, 235)"],

                hoverBackgroundColor: ["rgb(255, 99, 132)", "rgb(54, 162, 235)"],

                // borderColor: "#4e73df",
                data: [one1, Two1],
            }],
        },

        options: {
            maintainAspectRatio: false,
            plugins: {
                labels: {
                    render: 'percentage',
                    fontColor: '#fff',
                    precision: 2,
                    fontSize: 10
                }
            },

            legend: {
                display: true
            },
            cutoutpercentage: 20
        }
    });
