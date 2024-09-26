$(document).ready(function () {
    $('.delete').on('click', function () {
        var element = $(this);
        const sweetalert = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-danger mx-2",
                cancelButton: "btn btn-secondary"
            },
            buttonsStyling: false
        });
        sweetalert.fire({
            title: "Are you sure that you want to delete this game?",
            text: "You won't be able to revert this!",
            imageUrl: `/assests/images/${element.data('image')}`,
            imageWidth: 400,
            imageHeight: 300,
            imageAlt: element.data('alt'),
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    method: 'Delete',
                    url: `/Games/Delete/${element.data('id')}`,
                    success: function () {
                        sweetalert.fire({
                            title: "Deleted!",
                            text: "Game has been deleted.",
                            icon: "success"
                        });
                        element.parents('tr').fadeOut();
                    },
                    error: function () {
                        sweetalert.fire({
                            title: "Ooops!",
                            text: "Something wrong.",
                            icon: "error"
                        });
                    }
                });
            }
        });
        
    })
});

