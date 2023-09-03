  
    <script>
        $(document).ready(function () {
            // Initialize Select2 on all select elements
            $('select').select2();

            // File input change event handling
            $('#Cover').on('change', function () {
                $('.cover-preview').attr('src', window.URL.createObjectURL(this.files[0])).removeClass('d-none');
            });

            // Custom validator method for file size
            $.validator.addMethod('filesize', function (value, element, param) {
                return this.optional(element) || element.files[0].size <= param;
            });

            // Form validation
            $('#YourForm').validate({
                rules: {
                    username: 'required', // Add rules for your form inputs here
                    attachment: {
                        required: true,
                        filesize: 102400 // Example: Maximum file size of 100 KB (adjust as needed)
                    }
                },
                messages: {
                    username: 'Please enter a username.', // Customize error messages here
                    attachment: {
                        required: 'Please select a file.',
                        filesize: 'File size must be less than or equal to {0} bytes.'
                    }
                },
                submitHandler: function (form) {
                    // Handle form submission here if it's valid
                    alert('Form submitted successfully!');
                }
            });
        });
    </script>




