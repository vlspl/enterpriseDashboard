

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

var ctx = document.getElementById("bar_chart");
var myChart = new Chart(ctx, {

    type: 'bar',
    data: {
        labels: ["Healthy", "Unhealthy"],
        datasets: [{
            label: "Male",
            // data: [68, 22, 24, 30, 32],
            data: [one1, Two1],
            backgroundColor: 'rgba(0, 188, 212, 0.8)'
        }, {
            label: "Female",
            // data: [11, 25, 26, 28, 35],                   
            data: [one, Two],
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



//for stack bar chart dynamic data
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
            xAxes: {
                ticks: {
                    autoSkip: false,
                    maxRotation: 45,
                    minRotation: 45
                },
                stacked: true,
            },
            //            x: {
            //                stacked: true,
            //            },
            y: {
                stacked: true
            }
        }
    }



});