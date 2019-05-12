function addAuthor(item) {
    var id = $(item).data('assigned-id');
    var author = item.value;
    fetch("AddAuthor" + '?pubId=' + id + '&author=' + author).then(function (data) {
        location.reload()
    });
}