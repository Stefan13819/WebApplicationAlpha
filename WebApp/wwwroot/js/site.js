document.addEventListener("DOMContentLoaded", () => {
    // Quill Initialization
    const addProjectDescriptionTextarea = document.getElementById('add-project-description');
    const quillEditor = document.getElementById('add-project-description-wysiwyg-editor');

    if (quillEditor && addProjectDescriptionTextarea) {
        const addProjectDescriptionQuill = new Quill(quillEditor, {
            modules: {
                syntax: true,
                toolbar: '#add-project-description-wysiwyg-toolbar'
            },
            theme: 'snow',
            placeholder: 'Type something'
        });

        addProjectDescriptionQuill.on('text-change', function () {
            addProjectDescriptionTextarea.value = addProjectDescriptionQuill.root.innerHTML;
        });
    } else {
        console.error('Quill container or textarea not found.');
    }

    // Dropdown Handling
    const dropdowns = document.querySelectorAll('[data-type="dropdown"]');
    document.addEventListener('click', function (event) {
        let clickedDropdown = null;

        dropdowns.forEach(dropdown => {
            const targetId = dropdown.getAttribute('data-target');
            const targetElement = document.querySelector(targetId);

            if (dropdown.contains(event.target)) {
                clickedDropdown = targetElement;

                // Close other dropdowns
                document.querySelectorAll('.dropdown.dropdown-show').forEach(openDropdown => {
                    if (openDropdown !== targetElement) {
                        openDropdown.classList.remove('dropdown-show');
                    }
                });

                // Toggle current
                targetElement.classList.toggle('dropdown-show');
            }
        });

        // Click outside any dropdown
        if (!clickedDropdown && !event.target.closest('.dropdown')) {
            document.querySelectorAll('.dropdown.dropdown-show').forEach(openDropdown => {
                openDropdown.classList.remove('dropdown-show');
            });
        }
    });

    // Modal Handling
    const openButtons = document.querySelectorAll('[data-type="modal"]');
    const closeButtons = document.querySelectorAll('[data-type="close"]');

    openButtons.forEach(button => {
        button.addEventListener('click', () => {
            const targetId = button.getAttribute('data-target');
            const modal = document.querySelector(targetId);
            if (modal) modal.style.display = 'flex'; // open the modal
        });
    });

    closeButtons.forEach(button => {
        button.addEventListener('click', () => {
            const targetId = button.getAttribute('data-target');
            const modal = document.getElementById(targetId);
            if (modal) modal.style.display = 'none'; // close the modal
        });
    });
});
