//Elementos do html
const insertButton = document.querySelector('.insertButton');
const productForm = document.getElementById('productRegister');
const imgUrl = document.querySelector('.img');
const productIdInput = document.getElementById('productId');
const submitButton = document.querySelector('.buttonRegister');
const modalTitle = document.querySelector('#productForm .modal-title');
const placeHolderImage = document.getElementById('imgInput');
const editButton = document.querySelectorAll('.editButton');

//Substituição de place holder;

    placeHolderImage.addEventListener('change', function () {
        const file = this.files[0];

        if (file) {
            const reader = new FileReader();

            reader.onload = function (e) {
                imgUrl.src = e.target.result;
            }

            reader.readAsDataURL(file);
        }
    });
//Reset form
    function resetModal() { 

        productForm.reset();
        productForm.action = "/InsertProducts/Create"

        productIdInput.value = 0;

        submitButton.innerText = "Cadastrar";
        modalTitle.innerText = "Preencha os requisitos";

        imgUrl.src = "icons/imgHolderIcon.png";
    }

    if (insertButton) {
        insertButton.addEventListener('click', function () {
            resetModal();
        });
    }

    //EditModal
    editButton.forEach(button => {

        button.addEventListener('click', function () {

            const productId = this.dataset.productId;
            const url = `/InsertProducts/Edit/${productId}`;

            fetch(url)
                .then(response => response.json())
                .then(data => {
                        
                    imgUrl.src = data.imgUrl;
                    document.getElementById('productId').value = data.id;
                    document.getElementById('name').value = data.name;
                    document.getElementById('price').value = String(data.price).replace('.', ',');
                    document.getElementById('type').value = data.type;

                    document.querySelector('#productForm .modal-title').innerText = "Alterar produto cadastrado";
                    document.querySelector('.buttonRegister').innerText = "Salvar alteração";

                    document.getElementById('productRegister').action = '/InsertProducts/Update';
                });
        });
    });
