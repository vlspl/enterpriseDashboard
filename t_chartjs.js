$(function () {
   
    new Chart(document.getElementById("bar_chart").getContext("2d"), getChartJs('bar'));
    //**new Chart(document.getElementById("radar_chart").getContext("2d"), getChartJs('radar'));
  //  new Chart(document.getElementById("pie_chart").getContext("2d"), getChartJs('pie'));
    //**new Chart(document.getElementById("donut_chart").getContext("2d"), getChartJs('doughnut'));
    new Chart(document.getElementById("h_bar_chart").getContext("2d"), getChartJs('bar_h'));
    new Chart(document.getElementById("emp_bar_chart").getContext("2d"), getChartJs('emp_bar'));
   // new Chart(document.getElementById("health_pie_chart").getContext("2d"), getChartJs('health_pie'));
    /* new Chart(document.getElementById("line_chart").getContext("2d"), getChartJs('line'));*/
    new Chart(document.getElementById("bar_chart_stacked").getContext("2d"), getChartJs('bar_stacked'));
});




// COVID VACCINATED
var lbl_v_count = $('#h_v_count').val();
var ar_v_count = lbl_v_count.split(",");
var vc1 = ar_v_count[0];
var vc2 = ar_v_count[1];
var vc3 = ar_v_count[2];
var ctx = document.getElementById("pie_chart");
var myChart = new Chart(ctx, {
    type: 'pie',

    data: {
        labels: ["Fully", "Not", "Partially"],
        datasets: [{

            data: [vc1, vc2, vc3],
            lineTension: 0.5,
            pointBorderColor: "transparent",
            backgroundColor: [

                "rgb(233, 30, 99)",// for fully
                "rgb(255, 193, 7)",// for partially
                "rgb(0, 188, 212)"// for not
            ],
        }]
    },
    options: {
        scales: {
        }
    }
});

jQuery("#pie_chart").click(
    function (evt) {
        window.location.href = "https://gov.visionarylifescience.com/dtl_chart.aspx?g_dtls='covid'";
        //var activePoints = pie_chart.getSegmentsAtEvent(evt);
        // alert(activePoints);

    }
);








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
 
    //for dynamic data vertical bar chart for blood group
    var lbl_v_status = $('#hBGgender').val();
    var ar_blg_status = lbl_v_status.split(",");
    var bg1 = ar_blg_status[0];
    var bg2 = ar_blg_status[1];
    var bg3 = ar_blg_status[2];
    var bg4 = ar_blg_status[3];
    var bg5 = ar_blg_status[4];
    var bg6 = ar_blg_status[5];
    var bg7 = ar_blg_status[6];
    var bg8 = ar_blg_status[7];

    var lbl_v_count = $('#hbldgrpCount').val();
    var ar_blg_count = lbl_v_count.split(",");
    var bgc1 = ar_blg_count[0];
    var bgc2 = ar_blg_count[1];
    var bgc3 = ar_blg_count[2];
    var bgc4 = ar_blg_count[3];
    var bgc5 = ar_blg_count[4];
    var bgc6 = ar_blg_count[5];
    var bgc7 = ar_blg_count[6];
    var bgc8 = ar_blg_count[7];
   
    //for dynamic data bar chart for test count
    var lbl_v_status = $('#htestStatus').val();
    var ar_t_status = lbl_v_status.split(",");
    var ts1 = ar_t_status[0];
    var ts2 = ar_t_status[1];
    var ts3 = ar_t_status[2];

    var lbl_v_count = $('#htestCount').val();
    var ar_t_count = lbl_v_count.split(",");
    var tc1 = ar_t_count[0];
    var tc2 = ar_t_count[1];
    var tc3 = ar_t_count[2];


    //for dynamic data bar chart for employee health
    var lbl_v_status = $('#HhealthName').val();
    var ar_h_status = lbl_v_status.split(",");
    var hs1 = ar_h_status[0];
    var hs2 = ar_h_status[1];
    var hs3 = ar_h_status[2];

    var lbl_v_count = $('#HhealthCount').val();
    var ar_h_count = lbl_v_count.split(",");
    var hc1 = ar_h_count[0];
    var hc2 = ar_h_count[1];
    var hc3 = ar_h_count[2];

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

    if (type === 'line') {
        config = {
            type: 'line',
            data: {
                //labels: ["HR", "Account", "Finance", "Sales", "Marketing", "Development", "Support"],
                // labels: ["HR", "A/C_Finance", "IT", "Operations", "Marketing", "Sales", "Support"],
                labels: [d1, d2, d3, d4, d5, d6, d7],
                datasets: [{
                    label: "Male",
                    //data: [65, 59, 80, 81, 56, 55, 40],
                    data: [m1, m2, m3, m4, m5, m6, m7],
                    borderColor: 'rgba(0, 188, 212, 0.75)',
                    backgroundColor: 'rgba(0, 188, 212, 0.3)',
                    pointBorderColor: 'rgba(0, 188, 212, 0)',
                    pointBackgroundColor: 'rgba(0, 188, 212, 0.9)',
                    pointBorderWidth: 1
                }, {
                    label: "Female",
                    // data: [28, 48, 40, 19, 86, 27, 90],
                    data: [f1, f2, f3, f4, f5, f6, f7],
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
     if (type === 'bar') {
       

        config = {
            type: 'bar',
            data: {
                labels: ["18-25", "26-35", "36-45", "46-60", "60+"],
                datasets: [{
                    label: "Female",
                    // data: [68, 22, 24, 30, 32],
                      data: [one1, Two1, Three1, Four1, Five1],
                     backgroundColor: 'rgba(233, 30, 99, 0.8)'
                  
                   
                }, {
                    label: "Male",
                    // data: [11, 25, 26, 28, 35],                   
                    
                data: [one, Two, Three, Four, Five],
                     backgroundColor: 'rgba(0, 188, 212, 0.8)'
                }]
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
    
    else if (type === 'pie') {
        config = {
            type: 'pie',
            data: {
                datasets: [{
                    data: [vc1, vc2, vc3],
                    //data: [100,200,150],
                    backgroundColor: [
                        "rgb(233, 30, 99)",
                        "rgb(255, 193, 7)",
                        "rgb(0, 188, 212)"
                        
                    ],
                }],
                labels: ["Fully", "Not", "Partially"],
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
                    onClick(e) {
                        const activePoints = myChart.getElementsAtEventForMode(e, 'nearest', {
                            intersect: true
                        }, false)
                        const [{
                            index
                        }] = activePoints;
                        console.log(datasets[0].data[index]);
                    }
                }
            }
        }
    }

    else if (type === 'doughnut') {
        config = {
            type: 'doughnut',
            data: {
                labels: ['Blood Pressure', 'Diabetes', 'Heart Ailment', 'Thyroid', 'Overweight and Obesity'],

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
                //labels: ['Blood Pressure', 'Diabetes', 'Heart Ailment', 'Thyroid', 'Overweight and Obesity'],
            },
            options: {
                plugins: {
                    datalabels: {
                        display: true,
                       
                        formatter: (value) => {
                            return value + '%';
                        }
                    }
                }
            }
        }


    }

    else if (type === 'bar_h') {

        config = {
            type: 'bar',
            data: {
                labels: ["A +Ve", "A -Ve", "B +Ve", "B -Ve", "O +Ve", "O -Ve", "AB +Ve","AB -Ve"],
                datasets: [{
                    label: "Female",
                    // data: [11, 25, 26, 28, 35],                   
                   data: [bgc1, bgc2, bgc3, bgc4, bgc5, bgc6, bgc7, bgc8],
                  // data: [bg1, bg2, bg3, bg4, bg5, bg6, bg7, bg8],
                   backgroundColor: 'rgba(233, 30, 99, 0.8)'
                  
                    /*backgroundColor: 'rgba(233, 30, 99, 0.8)'*/
                }, {
                    

                      label: "Male",
                    // data: [68, 22, 24, 30, 32],
                    data: [bg1, bg2, bg3, bg4, bg5, bg6, bg7, bg8],
                  //  data: [bgc1, bgc2, bgc3, bgc4, bgc5, bgc6, bgc7, bgc8],
                      backgroundColor: 'rgba(0, 188, 212, 0.8)'
                    /*backgroundColor: 'rgba(0, 188, 212, 0.8)'*/
                }]
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
                      
                        position: 'top',
                    },
                    title: {
                        display: true,
                        //text: 'Chart.js Horizontal Bar Chart'
                    }
                }
            },
        }



    }
    else if (type === 'emp_bar') {

        config = {
            type: 'bar',
            data: {
                labels: ["Test Completed", "Test Pending", "Test Ongoing"],
                datasets: [{
                    label: "Test Count",
                    // data: [68, 22, 24, 30, 32],
                    data: [tc1, tc2, tc3],
                    backgroundColor: ['rgb(0,128,0)',
                        'rgb(0,0,255)',
                        'rgb(0, 188, 212)'
                    ]

                }]
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

//    else if (type === 'health_pie') {
//        config = {
//            type: 'pie',
//            data: {
//                datasets: [{
//                    //data: [150, 350, 500,25],
//                    data: [hc1, hc2],
//                    backgroundColor: [
//                        "rgb(0,128,0)",
//                        "rgb(255, 0, 0)"
//                        
//                    ],
//                }],
//                labels: ["Healthy", "Unhealthy"],
//            },

//            options: {
//                plugins: {
//                    datalabels: {
//                        display: true,
//                        align: 'bottom',
//                        backgroundColor: '#ccc',
//                        font: {
//                            size: 18,
//                        }
//                    },
//                }
//            }
//        }
//    }

   else if (type == 'bar_stacked') {
        config = {
            type: 'bar',
            data: {
                labels: [d1, d2, d3, d4, d5, d6, d7],
                datasets: [{
                label: "Female",
                    // data: [11, 25, 26, 28, 35],                   
                    data: [f1, f2, f3, f4, f5, f6, f7],
                   backgroundColor: 'rgba(233, 30, 99, 0.8)'
                  
                }, {
                    
                     label: "Male",
                    // data: [68, 22, 24, 30, 32],
                    data: [m1, m2, m3, m4, m5, m6, m7],
                      backgroundColor: 'rgba(0, 188, 212, 0.8)'
                }]
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
                },
                 responsive: true,
                scales: {
                    x: {
                        stacked: true,
                    },
                    y: {
                        stacked: true
                    }
                }
            }
        }
    }
   

    return config;
}

//canvasP.onclick = function (e) {
//    var slice = myPieChart.getElementAtEvent(e);
//    if (!slice.length) return; // return if not clicked on slice
//    var label = slice[0]._model.label;
//    window.open('http://localhost:24219/Detailspage.aspx?g_dtls=' + label);


//}

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
                    labels:array,// [one, Two, Three, Four, Five],

//            labels: [one, Two, Three, Four, Five],
//           // labels: ['Blood Pressure', 'Diabetes', 'Heart Ailment', 'Thyroid', 'Overweight and Obesity'],
            datasets: [{
            backgroundColor: ["rgb(255, 99, 132)", "rgb(255, 159, 64)", "rgb(255, 205, 86)", "rgb(75, 192, 192)", "rgb(54, 162, 235)"],
                
               // hoverBackgroundColor: ["#2e59d9", "#457dcc", "#ffc107", "#588a02", "#01908c"],

                // borderColor: "#4e73df",
               // data: [one1, Two1, Three1, Four1, Five1],
                data: array1,//[one1, Two1, Three1, Four1, Five1],
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

jQuery("#headCountPieChart").click(
    function (evt) {
        window.location.href = "https://gov.visionarylifescience.com/topVer.aspx?g_dtls='TV'";
        //var activePoints = pie_chart.getSegmentsAtEvent(evt);
        // alert(activePoints);

    }
);

/*pie chart for covid test */
var ctx = document.getElementById("testCountPieChart");
var labelName = $('#HAgegroupAmt').val();
var array = labelName.split(",");
var one = array[0];
var Two = array[1];
var Three = array[2];

//var testCountPieChart = new Chart(ctx, {
//    type: 'pie1',
//    data: {
//        labels: ["Not Vaccinated", "Fully Vaccinated", "Partially Vaccinated"],
//        datasets: [{

           
//            //backgroundColor: ["#3b00ed", "#18acf6", "#8e08a5"],
//            backgroundColor: ["rgb(233, 30, 99)", "rgb(255, 193, 7)", "rgb(0, 188, 212)"],

//            hoverBackgroundColor: ["#2e59d9", "#457dcc", "#cc6601"],
//            // borderColor: "#4e73df",
//            data: [one, Two, Three],
//        }],
//    },
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

                hoverBackgroundColor: ["#2e59d9", "#01908c"],

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

// emp health

var lbl_v_count = $('#HhealthCount').val();
var ar_h_count = lbl_v_count.split(",");
var hc1 = ar_h_count[0];
var hc2 = ar_h_count[1];
var hc3 = ar_h_count[2];
var ctx = document.getElementById("health_pie_chart");
var myChart = new Chart(ctx, {

    type: 'pie',
    data: {
        datasets: [{
            //data: [150, 350, 500,25],
            data: [hc1, hc2],
            backgroundColor: [
                "rgb(0,128,0)",
                "rgb(255, 0, 0)"

            ],
        }],
        labels: ["Healthy", "Unhealthy"],
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

});


jQuery("#health_pie_chart").click(
    function (evt) {
        window.location.href = "https://gov.visionarylifescience.com/empHealth.aspx?g_dtls='health'";
        //var activePoints = pie_chart.getSegmentsAtEvent(evt);
        // alert(activePoints);

    }
);




