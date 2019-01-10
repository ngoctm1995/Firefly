$(document).ready(function () {
    $(".btnDelete").html('<i class="fas fa-times" style="color:red" title="Xóa"></i>');
    $(".btnEdit").html('<i class="fas fa-pen-square" title="Sửa"></i>');
    $(".btnView").html('<i class="fas fa-eye" title="Xem chi tiết"></i>');
    // Nút thêm mới
    var btnAddHtml = $(".btnAdd").html();
    $(".btnAdd").html('<i class="fas fa-plus" title="Thêm mới"></i>&nbsp' + btnAddHtml);
    // Nút confirm
    var btnConfirmHtml = $(".btnConfirm").html();
    $(".btnConfirm").html('<i class="fas fa-check" title="Cập nhật"></i>&nbsp' + btnConfirmHtml);
});

function removeRow(rowId) {
    $("#row_" + rowId).remove();
}