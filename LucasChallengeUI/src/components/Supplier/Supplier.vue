<template>
    <div class="container">
        <div class="row">
            <div class="col-sm-10">
                <div class="d-flex justify-content-between align-items-center">
                    <h1>Fornecedor</h1>
                    <button class="btn btn-secondary btn-sm" type="button" @click="toCompany">
                        Empresas
                    </button>
                </div>
                <hr />
                <br /><br />
                <button class="btn btn-success btn-sm" type="button" @click="toggleAddBookModal">
                    Adicionar Fornecedor
                </button>
                <br /><br />
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">Documento</th>
                            <th scope="col">Nome</th>
                            <th scope="col">E-mail</th>
                            <th scope="col">Cep</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(suppliers, index) in suppliers" :key="index">
                            <td>{{ suppliers.cnpj_cpf }}</td>
                            <td>{{ suppliers.name }}</td>
                            <td>{{ suppliers.email }}</td>
                            <td>{{ suppliers.cep }}</td>
                            <td>
                                <div class="btn-group" role="group">
                                    <button class="btn btn-warning btn-sm" type="button" @click="toggleEditBookModal(book)">
                                        Update
                                    </button>
                                    <button class="btn btn-danger btn-sm" type="button" @click="handleDeleteBook(book)">
                                        Delete
                                    </button>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <!-- add new book modal -->
    <div ref="addBookModal" :class="{ show: activeAddBookModal, 'd-block': activeAddBookModal }" class="modal fade"
        role="dialog" tabindex="-1">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Add a new book</h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button" @click="toggleAddBookModal">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="mb-3">
                            <label class="form-label" for="addBookTitle">Title:</label>
                            <input id="addBookTitle" v-model="addBookForm.title" class="form-control"
                                placeholder="Enter title" type="text" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label" for="addBookAuthor">Author:</label>
                            <input id="addBookAuthor" v-model="addBookForm.author" class="form-control"
                                placeholder="Enter author" type="text" />
                        </div>
                        <div class="mb-3 form-check">
                            <input id="addBookRead" v-model="addBookForm.read" class="form-check-input" type="checkbox" />
                            <label class="form-check-label" for="addBookRead">Read?</label>
                        </div>
                        <div class="btn-group" role="group">
                            <button class="btn btn-primary btn-sm" type="button" @click="handleAddSubmit">
                                Submit
                            </button>
                            <button class="btn btn-danger btn-sm" type="button" @click="handleAddReset">
                                Reset
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div v-if="activeAddBookModal" class="modal-backdrop fade show"></div>
    <!-- edit book modal -->
    <div ref="editBookModal" :class="{ show: activeEditBookModal, 'd-block': activeEditBookModal }" class="modal fade"
        role="dialog" tabindex="-1">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Update</h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"
                        @click="toggleEditBookModal">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="mb-3">
                            <label class="form-label" for="editBookTitle">Title:</label>
                            <input id="editBookTitle" v-model="editBookForm.title" class="form-control"
                                placeholder="Enter title" type="text">
                        </div>
                        <div class="mb-3">
                            <label class="form-label" for="editBookAuthor">Author:</label>
                            <input id="editBookAuthor" v-model="editBookForm.author" class="form-control"
                                placeholder="Enter author" type="text">
                        </div>
                        <div class="mb-3 form-check">
                            <input id="editBookRead" v-model="editBookForm.read" class="form-check-input" type="checkbox">
                            <label class="form-check-label" for="editBookRead">Read?</label>
                        </div>
                        <div class="btn-group" role="group">
                            <button class="btn btn-primary btn-sm" type="button" @click="handleEditSubmit">
                                Submit
                            </button>
                            <button class="btn btn-danger btn-sm" type="button" @click="handleEditCancel">
                                Cancel
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div v-if="activeEditBookModal" class="modal-backdrop fade show"></div>
</template>
  
<script>
import axios from "axios";
export default {
    data() {
        return {
            activeAddBookModal: false,
            addBookForm: {
                id: "",
                title: "",
                author: "",
                read: [],
            },
            activeEditBookModal: false,
            editBookForm: {
                id: '',
                title: '',
                author: '',
                read: [],
            },
            suppliers: [],
            message: "",
            showMessage: false,
        };
    },
    components: {
    },
    methods: {
        addBook(payload) {
            const path = "http://127.0.0.1:5000/books";
            axios
                .post(path, payload)
                .then(() => {
                    this.getBooks();
                    this.message = "Book added";
                    this.showMessage = true;
                })
                .catch((error) => {
                    console.log(error);
                    this.getBooks();
                });
        },
        toCompany() {
            this.$router.push('/');
        },
        getBooks() {
            const path = "https://localhost:7253/supplier";
            axios
                .get(path)
                .then((res) => {
                    this.suppliers = res.data;
                })
                .catch((error) => {
                    console.error(error);
                });
        },
        handleAddReset() {
            this.initForm();
        },
        handleAddSubmit() {
            this.toggleAddBookModal();
            let read = false;
            if (this.addBookForm.read[0]) {
                read = true;
            }
            const payload = {
                title: this.addBookForm.title,
                author: this.addBookForm.author,
                read, // property shorthand
            };
            this.addBook(payload);
            this.initForm();
        },
        initForm() {
            this.addBookForm.title = "";
            this.addBookForm.author = "";
            this.addBookForm.read = [];
            this.editBookForm.id = "";
            this.editBookForm.title = "";
            this.editBookForm.author = "";
            this.editBookForm.read = [];
        },
        toSupplier() {

        },
        toggleAddBookModal() {
            const body = document.querySelector("body");
            this.activeAddBookModal = !this.activeAddBookModal;
            if (this.activeAddBookModal) {
                body.classList.add("modal-open");
            } else {
                body.classList.remove("modal-open");
            }
        },
        toggleEditBookModal(book) {
            if (book) {
                this.editBookForm = book;
            }
            const body = document.querySelector("body");
            this.activeEditBookModal = !this.activeEditBookModal;
            if (this.activeEditBookModal) {
                body.classList.add("modal-open");
            } else {
                body.classList.remove("modal-open");
            }
        },
        handleEditSubmit() {
            this.toggleEditBookModal(null);
            let read = false;
            if (this.editBookForm.read) read = true;
            const payload = {
                title: this.editBookForm.title,
                author: this.editBookForm.author,
                read,
            };
            this.updateBook(payload, this.editBookForm.id);
        },
        updateBook(payload, bookID) {
            const path = `http://127.0.0.1:5000/books/${bookID}`;
            axios.put(path, payload)
                .then(() => {
                    this.getBooks();
                    this.message = 'Book updated!';
                    this.showMessage = true;
                })
                .catch((error) => {
                    console.error(error);
                    this.getBooks();
                });
        },
        handleEditCancel() {
            this.toggleEditBookModal(null);
            this.initForm();
            this.getBooks(); // why?
        },
        handleDeleteBook(book) {
            this.removeBook(book.id);
        },
        removeBook(bookID) {
            const path = `http://127.0.0.1:5000/books/${bookID}`;
            axios.delete(path)
                .then(() => {
                    this.getBooks();
                    this.message = 'Book removed!';
                    this.showMessage = true;
                })
                .catch((error) => {
                    console.error(error);
                    this.getBooks();
                });
        },
    },
    created() {
        this.getBooks();
    },
};
</script>
  