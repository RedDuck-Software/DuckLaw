function Test() {
    document.designMode = 'on';

    var key = 0;
    var selectArray = [];

    function objToRange(rangeStr) {
        range = document.createRange();
        range.setStart(document.querySelector('[data-key="' + rangeStr.startKey + '"]').childNodes[rangeStr.startTextIndex], rangeStr.startOffset);
        range.setEnd(document.querySelector('[data-key="' + rangeStr.endKey + '"]').childNodes[rangeStr.endTextIndex], rangeStr.endOffset);
        return range;
    }

    function rangeToObj(range) {
        return {
            startKey: range.startContainer.parentNode.dataset.key,
            startTextIndex: Array.prototype.indexOf.call(range.startContainer.parentNode.childNodes, range.startContainer),
            endKey: range.endContainer.parentNode.dataset.key,
            endTextIndex: Array.prototype.indexOf.call(range.endContainer.parentNode.childNodes, range.endContainer),
            startOffset: range.startOffset,
            endOffset: range.endOffset
        }
    }

    document.getElementById('textToSelect').addEventListener('mouseup', function (e) {
        if (confirm('highlight?')) {
            var range = document.getSelection().getRangeAt(0);
            selectArray.push(rangeToObj(range));
            document.execCommand('hiliteColor', false, 'yellow')
        }
    });

    function addKey(element) {
        if (element.children.length > 0) {
            Array.prototype.forEach.call(element.children, function (each, i) {
                each.dataset.key = key++;
                addKey(each)
            });
        }
    };

    document.getElementById('getSelectionString').addEventListener('click', function () {
        alert('Copy string to save selections: ' + JSON.stringify(selectArray));
    });

    document.getElementById('setSelection').addEventListener('click', function () {
        var selStr = prompt('Paste string');
        var selArr = JSON.parse(selStr);
        var sel = getSelection();
        selArr.forEach(function (each) {
            sel.removeAllRanges();
            sel.addRange(objToRange(each));
            document.execCommand('hiliteColor', false, 'yellow')
        })
    });

    addKey(document.body);
}