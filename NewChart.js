$(function () {
    
    new Chart(document.getElementById("bar_chart1").getContext("2d"), getChart('barNew'));
    new Chart(document.getElementById("donut_chart1").getContext("2d"), getChart('doughnutNew'));
    new Chart(document.getElementById("pie_chart1").getContext("2d"), getChart('pieNew'));
});
function getChart(type) {
    var config = null;
    //if (type === 'barNew') {
    //    config = {
    //        type: 'barNew',
    //        data: {
    //            labels: ["A+", "A-", "B+", "B-", "O+"],
    //            datasets: [{
    //                label: "Male",
    //                data: [65, 59, 80, 81, 56],
    //                backgroundColor: 'rgba(0, 188, 212, 0.8)'
    //            }, {
    //                label: "Female",
    //                data: [28, 48, 40, 19, 86],
    //                backgroundColor: 'rgba(233, 30, 99, 0.8)'
    //            }]
    //        },
    //        //options: {
    //        //    responsive: true,
    //        //    legend: false
    //        //}
    //        options: {
    //            plugins: {
    //                datalabels: {
    //                    display: true,
    //                    align: 'bottom',
    //                    backgroundColor: '#ccc',
    //                    font: {
    //                        size: 18,
    //                    }
    //                },
    //            }
    //        }
    //    }
    //}
  
    if (type === 'barNew') {
        config = {
            type: 'barNew',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    data: [65, 59, 80, 81, 56, 55, 40],
                    backgroundColor: 'rgba(0, 188, 212, 0.8)'
                }, {
                    label: "My Second dataset",
                    data: [28, 48, 40, 19, 86, 27, 90],
                    backgroundColor: 'rgba(233, 30, 99, 0.8)'
                }]
            },
            options: {
                responsive: true,
                legend: false
            }
        }
    }
    else if (type === 'pieNew') {
        config = {
            type: 'pieNew',
            data: {
                datasets: [{
                    data: [150, 350, 500],
                    backgroundColor: [
                        "rgb(233, 30, 99)",
                        "rgb(255, 193, 7)",
                        "rgb(0, 188, 212)",
                        "rgb(139, 195, 74)"
                    ],
                }],
                labels: [
                    "Healthy",
                    "Unhealthy",
                    "Fully Vaccinated"
                ],
            },
            //options: {
            //    display: true,
            //    responsive: true,
            //    legend: true
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
 
    else if (type === 'doughnutNew') {
        config = {
            type: 'doughnutNew',
            data: {
                datasets: [
                    {
                        data: [25, 20, 15, 10, 30],
                        backgroundColor: ['rgb(255, 99, 132)',
                            'rgb(255, 159, 64)',
                            'rgb(255, 205, 86)',
                        ],
                    },
                ],
                /* labels: ['Heart Disease', 'High Blood Pressure', 'Stroke', 'Diabetes', 'Other'],*/
                labels: ['Test Completed', 'Test Pending', 'Test Ongoing'],
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

    return config;
}