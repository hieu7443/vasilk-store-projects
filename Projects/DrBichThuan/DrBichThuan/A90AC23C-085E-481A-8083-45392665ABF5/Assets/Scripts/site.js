$(function () {
    var _app = {
        onLoad: [],
        onScroll: [],
        afterScroll: [],
        onResize: [],
        afterResize: [],
        waiter: {
            googleMap: null,
            scroll: null,
            resize: null
        }
    };
    var lastScrollTop = 0;
    var fixedTop = 0;
    $(document).ready(function () {
        _app.onLoad.forEach(function (e, i) {
            e();
        });
    });
    $(window).on('scroll', function () {
        _app.onScroll.forEach(function (e, i) {
            e();
        });
        if (_app.waiter.scroll != null)
            window.clearInterval(_app.waiter.scroll);
        _app.waiter.scroll = window.setInterval(function () {
            _app.afterScroll.forEach(function (e, i) {
                e();
            });
            window.clearInterval(_app.waiter.scroll);
            _app.waiter.scroll = null;
        }, 300);
    });
    $(window).on('resize', function () {
        _app.onResize.forEach(function (e, i) {
            e();
        });
        if (_app.waiter.resize != null)
            window.clearInterval(_app.waiter.resize);
        _app.waiter.resize = window.setInterval(function () {
            _app.afterResize.forEach(function (e, i) {
                e();
            });
            window.clearInterval(_app.waiter.resize);
            _app.waiter.resize = null;
        }, 300);
    });
    function _ajaxRequest(data) {
        $.ajax({
            url: data.url,
            dataType: "json",
            type: data.type ? data.type : 'GET',
            data: data.data,
            async: true,
            contentType: false,
            processData: data.processData ? true : data.processData,
            cache: false,
            xhr: function () {
                var xhr = new window.XMLHttpRequest();
                if (data.uploadProgress) {
                    xhr.upload.addEventListener("progress", function (evt) {
                        if (evt.lengthComputable) {
                            var percentComplete = evt.loaded / evt.total;
                            data.uploadProgress(percentComplete);
                        }
                    }, false);
                }
                if (data.downloadProgress) {
                    xhr.addEventListener("progress", function (evt) {
                        if (evt.lengthComputable) {
                            var percentComplete = evt.loaded / evt.total;
                            data.downloadProgress(percentComplete);
                        }
                    }, false);
                }
                return xhr;
            },
            beforeSend: data.beforeSend,
            complete: data.complete,
            success: data.success,
            error: data.error
        });
    }
    function _renderCover(item) {
        var item = $(item),
            fixed = item.data('cover');
        item.find('.cover').remove();
        if (fixed == 'fixed')
            item.prepend('<div class="cover fixed dark" style="margin-bottom: -' + item.height() + 'px"><span class="centerer"></span><div class="centered"><div class="uil-ring-css"><span></span></div></div></div>');
        else
            item.prepend('<div class="cover dark"><span class="centerer"></span><div class="centered"><div class="uil-ring-css"><span></span></div></div></div>');
    }
    function _renderHtml(el, html) {
        if (html)
            $(el).html(html);
        _renderElement(el);
        if ($(el).hasClass('modal-content')) {
            var modal = $($(el).data('modal'));
            modal.modal('show');
            modal.find('input[autofocus]').trigger('focus');
            modal.find('button[data-button-type="close"]').on('click', function () {
                modal.modal('hide');
            });
        }
    }
    function _renderElement(el) {
        _renderButton(el);
        $(el).find('[data-remove]').remove();
    }
    function _ajaxLoad(url, type, target, loadingTarget, success, error) {
        if (loadingTarget && loadingTarget != '')
            loadingTarget = $(loadingTarget);
        else
            loadingTarget = null;
        _ajaxRequest({
            url: url,
            type: type,
            beforeSend: function () {
                if (loadingTarget)
                    _renderCover(loadingTarget);
                else
                    _renderCover(target);
            },
            success: function (data) {
                _renderHtml(target, data);
                if (success)
                    success(data);
            },
            error: error,
            complete: function () {
                if (loadingTarget)
                    loadingTarget.find('.cover').remove();
            }
        });
    }
    function _renderButtonUrl(btn) {
        var url = btn.data('url');
        if (url != undefined && url != '') {
            btn.find('[data-input]').each(function (i, e) {
                var input = $($(e).data('input'));
                if (input.length > 0) {
                    var name = $(e).data('name'),
                        value = input.val();
                    if (name == undefined || name == '')
                        name = input.attr('name');
                    url = _appendUrl(url, name, value);
                }
            });
            btn.find('[data-append-url]').each(function (i, e) {
                var target = $($(e).data('target')),
                    name = $(e).data('name'),
                    value = $(e).data('value');
                if (target.length > 0) {
                    url = _appendUrl(url, name, target.attr(value));
                } else {
                    url = _appendUrl(url, name, value);
                }
            });
        }
        return url;
    }
    function _renderButton(el) {
        $(el).find('button[data-ajax-content]').each(function (i, e) {
            var url = _renderButtonUrl($(e)),
                target = $('[data-ajax-content-target="' + $(e).data('target') + '"]'),
                loadingTarget = $(e).data('loading-target');
            if (url != undefined && url != '') {
                _ajaxLoad(url, 'post', target, loadingTarget, function () {
                    target.removeAttr('data-ajax-content-target');
                });
            }
            $(e).remove();
        });
    }
    function _renderMap(el) {
        $(el).find('.google-map').each(function (i, e) {
            var address = $(e).data('adr'),
                lng = $(e).data('lng'),
                lat = $(e).data('lat');
            var map = new google.maps.Map(e, { zoom: 15, center: { lat: lat, lng: lng } });
            var geocoder = new google.maps.Geocoder();
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status === 'OK') {
                    map.setCenter(results[0].geometry.location);
                    var marker = new google.maps.Marker({
                        map: map,
                        position: results[0].geometry.location
                    });
                } else {
                    var marker = new google.maps.Marker({ position: { lat: lat, lng: lng }, map: map });
                }
            });
        });
    }
    function fixedPosition() {
        var scrollTop = $(window).scrollTop(),
			screen = $(window).height(),
			header = $('header').height(),
			body = $('#body').height(),
			fixed = $('#fixed').height(),
			additional = fixed <= screen ? 0 : fixed - screen,
			value = 0;
        if (scrollTop >= header + additional && scrollTop <= body + header + additional - fixed) {
            value = scrollTop - header;
        } else if (scrollTop > body + header + additional - fixed) {
            value = body - fixed;
        }
        $('#fixed').css({ 'top': value + 'px' });
        fixedTop = value;
        lastScrollTop = scrollTop;
    }
    _renderButton('body');
    if (googleMapAvailable) {
        _renderMap('body');
    } else {
        _app.waiter.googleMap = window.setInterval(function () {
            if (googleMapAvailable) {
                window.clearInterval(_app.waiter.googleMap);
                _renderMap('body');
            }
        }, 5000);
    }
    _app.onScroll.push(function () {
        var scrollTop = $(window).scrollTop(),
			change = scrollTop - lastScrollTop;
        lastScrollTop = scrollTop;
        var screen = $(window).height(),
			header = $('header').height(),
			body = $('#body').height(),
			fixed = $('#fixed').height(),
			additional = fixed <= screen ? 0 : fixed - screen,
			value = 0,
			isScrollDown = change > 0,
			minScroll = header + (isScrollDown ? additional : 0),
			maxScroll = body + header + (isScrollDown ? additional : 0) - fixed;
        if (scrollTop >= minScroll && scrollTop <= maxScroll) {
            var target = isScrollDown ? scrollTop - header + screen - fixed : scrollTop - header,
				value = fixedTop, changeValue = Math.abs(change), diff = Math.abs(target - value);
            changeValue = changeValue > diff ? diff : changeValue;
            value = target > value ? value + changeValue : value - changeValue;
        } else if (scrollTop > maxScroll) {
            value = body - fixed;
        }
        $('#fixed').css({ 'top': value + 'px' });
        fixedTop = value;
    });
    _app.afterResize.push(function () {
        fixedPosition();
    });
    _app.onLoad.push(function () {
        fixedPosition();
    });
    $('header,footer,#body').removeClass('hidden');
    $('#page-loading').remove();
});