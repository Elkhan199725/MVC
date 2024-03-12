﻿
let deleteBtns = document.querySelectorAll(".delete-btn");

deleteBtns.forEach(btn => {
    btn.addEventListener("click", function (e) {
        let url = btn.getAttribute("href"); 

        e.preventDefault();
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then((result) => {
            if (result.isConfirmed) {

                fetch(url)
                    .then(response => {
                        if (response.status == 200) {

                            Swal.fire({
                                title: "Deleted!",
                                text: "Your file has been deleted.",
                                icon: "success"
                            }).then(() => {
                                // Wait for 1 second before reloading the page
                                setTimeout(function () {
                                    window.location.reload(true);
                                }, 1000); // 1000 milliseconds = 1 second
                            });

                        } else {
                            alert("file is not exist!")
                        }
                    });

            }
        });
    })
})