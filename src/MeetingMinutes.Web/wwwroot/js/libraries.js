// Initialize bootstrap toast message
const ToastColor = {
    Red: 'danger',
    Green: 'success',
    Yellow: 'warning',
    Blue: 'primary'
}

function toastMessage(message, type = ToastColor.Red, timer = 6000) {
    let container = $('#toast-container')
    if (container.length === 0) {
        container = $('<div>').attr('id', 'toast-container').css({
            'position': 'fixed',
            'z-index': 11,
            'bottom': '40px',
            'right': '0',
            'margin-right': '0.5rem'
        }).appendTo('body')
    }

    let toastDiv = $('<div>').addClass('toast align-items-center text-bg-' + type + ' border-0 mb-2')
        .attr({
            'role': 'alert',
            'aria-live': 'assertive',
            'aria-atomic': 'true',
            'data-bs-delay': timer
        })
        .html(`
            <div class="d-flex">
                <div class="toast-body">
                    ${message}
                </div>
                <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
        `)

    container.append(toastDiv)
    new bootstrap.Toast(toastDiv[0]).show()
}

function toastMessageNext(message, type = ToastColor.Red, timer = 6000) {
    let toastMessage = {
        message: message,
        type: type,
        timer: timer
    }

    sessionStorage.setItem('toastMessage', JSON.stringify(toastMessage))
}


// Initialize tippy.js
tippy.setDefaultProps({
    delayanimation: 'perspective-subtle',
    theme: 'light'
})

function setTippyContent() {
    tippy('[pop]', {
        content: (reference) => reference.getAttribute('pop')
    })
}

setTippyContent()