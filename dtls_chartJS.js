
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

// COVID VACCINATED
var lbl_v_count = $('#h_v_count').val();
var ar_v_count = lbl_v_count.split(",");
var vc1 = ar_v_count[0];
var vc2 = ar_v_count[1];
var vc3 = ar_v_count[2];
var vc4 = ar_v_count[3];
var ctx = document.getElementById("pie_chart");
var myChart = new Chart(ctx, {
    type: 'pie',

    data: {
        labels: ["Fully Vaccinated", "Partially Vaccinated", "Not Vaccinated","Booster"],
        datasets: [{

            data: [vc2, vc4, vc3 , vc1],
           // data: [156, 150, 120],
            lineTension: 0.5,
            pointBorderColor: "transparent",
            backgroundColor: [

                "rgb(233, 30, 99)",// for fully
                "rgb(255, 193, 7)",// for partially
                "rgb(0, 188, 212)",// for not
                "rgb(0, 108, 212)"
            ],
        }]
    },
    options: {
        scales: {
        }
    }
});

// bar chart
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

//var ctx = document.getElementById("emp_bar_chart");
//var myChart = new Chart(ctx, {
   
//    type: 'bar1',
//    data: {
//        labels: ["Covaxin", "Covishield", "Sputnik V"],
//        datasets: [{
//            label: "Vaccine Name",
//            // data: [68, 22, 24, 30, 32],
//            data: [tc1, tc2, tc3],
//            //BorderWidth = 10,
//            backgroundColor: [

//                "rgb(233, 30, 99)",// for fully
//                "rgb(255, 193, 7)",// for partially
//                "rgb(0, 188, 212)"// for not
//            ]

//        }]
//    },
    
//    options: {    
//        plugins: {
//            datalabels: {
//                display: true,
//               align: 'bottom',
//               backgroundColor: '#ccc',
//                legend: true,
//                //BarLength: 2,
//                font: {
//                    size: 18,
//                }
//            },
//        },
      
//    }
    
//});



var ctx = document.getElementById("bar_chart");
var myChart = new Chart(ctx, {

    type: 'bar',
    data: {
        labels: ["Covaxin", "Covishield", "Sputnik V"],
        datasets: [{
            label: "Male",
            // data: [68, 22, 24, 30, 32],
            data: [one1, Two1, Three1],
            backgroundColor: 'rgba(0, 188, 212, 0.8)'
        }, {
            label: "Female",
            // data: [11, 25, 26, 28, 35],                   
            data: [one, Two, Three],
            backgroundColor: 'rgba(233, 30, 99, 0.8)'
        }]
    },

    options: {
        plugins: {
            datalabels: {
                display: true,
                align: 'bottom',
                backgroundColor: '#ccc',
                legend: true,
                //BarLength: 2,
                font: {
                    size: 18,
                }
            },
        },

    }

});

//Line chart


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



var ctx = document.getElementById("bar_stacked");
var myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: [d1, d2, d3, d4, d5, d6, d7],
        datasets: [{
            label: "Male",
            // data: [68, 22, 24, 30, 32],
            data: [m1, m2, m3, m4, m5, m6, m7],
            backgroundColor: 'rgba(0, 188, 212, 0.8)'
        }, {
            label: "Female",
            // data: [11, 25, 26, 28, 35],                   
            data: [f1, f2, f3, f4, f5, f6, f7],
            backgroundColor: 'rgba(233, 30, 99, 0.8)'
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



});

