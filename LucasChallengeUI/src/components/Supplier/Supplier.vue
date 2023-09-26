<template>
    <div class="container">
        <div class="row">
            <div class="col-sm-10">
                <div class="d-flex justify-content-between align-items-center">
                    <h1>Fornecedores</h1>
                    <button class="btn btn-secondary btn-sm" type="button" @click="toCompany">
                        Empresas
                    </button>
                </div>
                <hr />
                <br /><br />
                <div class="d-flex align-items-center justify-content-between">

                    <button class="btn btn-success btn-sm" type="button" @click="toggleaddSupplierModal">
                        Adicionar Fornecedor
                    </button>
                    <div class="d-flex gap-2 align-items-center">

                        <form class="d-flex gap-2 align-items-center">
                            <div class="mb-3">
                                <label class="form-label" for="filterCpfCnpjid">CPF/CNPJ:</label>
                                <input id="filterCpfCnpjid" v-model="filter.filterCpfCnpj" class="form-control"
                                    placeholder="Digite seu Documento" type="text"
                                    v-mask="['###.###.###-##', '##.###.###/####-##']" />
                            </div>
                            <div class="mb-3">
                                <label class="form-label" for="filterNameid">Nome:</label>
                                <input id="filterNameid" v-model="filter.filterName" class="form-control"
                                    placeholder="Digite seu nome" type="text" />
                            </div>
                            <button class="btn btn-secondary btn-sm mt-3" type="button" @click="applyFilter">
                                Pesquisar
                            </button>
                        </form>

                    </div>
                </div>
                <br /><br />

                <div class="d-flex flex-column align-items-center">
                    <table class="table table-hover">
                        <!-- Cabeçalho da tabela -->
                        <thead>
                            <tr>
                                <th scope="col">Documento</th>
                                <th scope="col">Nome</th>
                                <th scope="col">Email</th>
                                <th scope="col">Cep</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <!-- Renderiza as linhas da tabela baseadas na página atual e quantidade de itens por página -->
                            <tr v-for="(supplier, index) in paginatedSupplies" :key="index">
                                <td>{{ supplier.cnpj_cpf }}</td>
                                <td>{{ supplier.name }}</td>
                                <td>{{ supplier.email }}</td>
                                <td>{{ supplier.cep }}</td>
                                <td>
                                    <div class="btn-group" role="group">
                                        <button class="btn btn-warning btn-sm mx-2" type="button"
                                            @click="toggleeditSupplierModal(supplier)">
                                            Atualizar
                                        </button>
                                        <button class="btn btn-danger btn-sm" type="button"
                                            @click="() => handleDeleteSupplier(supplier.id)">
                                            Deletar
                                        </button>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>

                    <!-- Paginação -->
                    <nav>
                        <ul class="pagination">
                            <li class="page-item" :class="{ 'disabled': currentPage === 1 }">
                                <button class="page-link" @click="changePage(currentPage - 1)" aria-label="Previous">
                                    <span aria-hidden="true">&laquo;</span>
                                </button>
                            </li>
                            <li class="page-item" v-for="page in pages" :key="page"
                                :class="{ 'active': page === currentPage }">
                                <button class="page-link" @click="changePage(page)">{{ page }}</button>
                            </li>
                            <li class="page-item" :class="{ 'disabled': currentPage === totalPages }">
                                <button class="page-link" @click="changePage(currentPage + 1)" aria-label="Next">
                                    <span aria-hidden="true">&raquo;</span>
                                </button>
                            </li>
                        </ul>
                    </nav>
                </div>

            </div>
        </div>
    </div>
    <!-- add new supplier modal -->
    <div ref="addSupplierModal" :class="{ show: activeAddSupplierModal, 'd-block': activeAddSupplierModal }"
        class="modal fade" role="dialog" tabindex="-1">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Adicionar novo Fornecedor</h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"
                        @click="toggleaddSupplierModal">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label class="form-label pe-2" for="addSupplierCNPJ_CPF">Pessoa Física?</label>
                        <input id="addSupplierCNPJ_CPF" v-model="addSupplierForm.isPessoaFisica" class="form-check-input"
                            type="checkbox" @click="toggleIsPessoaFisica('add')" />
                    </div>
                    <form>
                        <div class="mb-3">
                            <label class="form-label" for="addSupplierCNPJ_CPF">CPF/CNPJ:</label>
                            <input id="addSupplierCNPJ_CPF" v-model="addSupplierForm.cnpj_cpf" class="form-control"
                                placeholder="Digite seu Documento" type="text"
                                v-mask="['###.###.###-##', '##.###.###/####-##']" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label" for="addSupplierFantasyName">Nome:</label>
                            <input id="addSupplierFantasyName" v-model="addSupplierForm.name" class="form-control"
                                placeholder="Digite o Nome" type="text" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label" for="addSupplierFantasyEmail">Email:</label>
                            <input id="addSupplierFantasyEmail" v-model="addSupplierForm.email" class="form-control"
                                placeholder="Digite o Email" type="email" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label" for="addSupplierCep">Cep:</label>
                            <input id="addSupplierCep" v-model="addSupplierForm.cep" class="form-control"
                                placeholder="Digite o CEP" type="text" v-mask="'#####-###'" />
                        </div>
                        <div class="mb-3" v-if="addSupplierForm.isPessoaFisica">
                            <label class="form-label" for="addSupplierRg">RG:</label>
                            <input id="addSupplierRg" v-model="addSupplierForm.rg" class="form-control"
                                placeholder="Digite seu RG" type="text" v-mask="'###.###.##-#'" />
                        </div>

                        <div class="mb-3" v-if="addSupplierForm.isPessoaFisica">
                            <label class="form-label" for="addSupplierBirth_Data">Data de nascimento:</label>
                            <input id="addSupplierBirth_Data" v-model="addSupplierForm.birth_data" class="form-control"
                                placeholder="Digite sua data de nascimento" type="date" />
                        </div>
                        <div class="btn-group d-flex mb-3 mt-4" role="group">
                            <button class="btn btn-primary btn-sm mx-2" type="button" @click="handleAddSubmit">
                                Salvar
                            </button>
                            <button class="btn btn-danger btn-sm" type="button" @click="handleAddReset">
                                Resetar
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div v-if="activeAddSupplierModal" class="modal-backdrop fade show"></div>
    <!-- edit supplier modal -->
    <div ref="editSupplierModal" :class="{ show: activeeditSupplierModal, 'd-block': activeeditSupplierModal }"
        class="modal fade" role="dialog" tabindex="-1">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Atualizar Empresa</h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"
                        @click="toggleeditSupplierModal">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label class="form-label pe-2" for="editSupplierPf">Pessoa Física?</label>
                        <input id="editSupplierPf" class="form-check-input" type="checkbox"
                            @click="toggleIsPessoaFisica('edit')" v-model="editSupplierForm.pf" />
                    </div>
                    <form>
                        <div class="mb-3">
                            <label class="form-label" for="editSupplierCNPJ_CPF">CPF/CNPJ:</label>
                            <input id="editSupplierCNPJ_CPF" v-model="editSupplierForm.cnpj_cpf" class="form-control"
                                placeholder="Digite seu Documento" type="text"
                                v-mask="['###.###.###-##', '##.###.###/####-##']" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label" for="editSupplierFantasyName">Nome:</label>
                            <input id="editSupplierFantasyName" v-model="editSupplierForm.name" class="form-control"
                                placeholder="Digite o Nome" type="text" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label" for="editSupplierFantasyEmail">Email:</label>
                            <input id="editSupplierFantasyEmail" v-model="editSupplierForm.email" class="form-control"
                                placeholder="Digite o Email" type="email" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label" for="editSupplierCep">Cep:</label>
                            <input id="editSupplierCep" v-model="editSupplierForm.cep" class="form-control"
                                placeholder="Digite o CEP" type="text" v-mask="'#####-###'" />
                        </div>
                        <div class="mb-3" v-if="editSupplierForm.pf">
                            <label class="form-label" for="editSupplierRg">RG:</label>
                            <input id="editSupplierRg" v-model="editSupplierForm.rg" class="form-control"
                                placeholder="Digite seu RG" type="text" v-mask="'###.###.##-#'" />
                        </div>

                        <div class="mb-3" v-if="editSupplierForm.pf">
                            <label class="form-label" for="editSupplierBirth_Data">Data de nascimento:</label>
                            <input id="editSupplierBirth_Data" v-model="editSupplierForm.birth_data" class="form-control"
                                placeholder="Digite sua data de nascimento" type="date" />
                        </div>
                        <div class="btn-group d-flex mb-3 mt-3" role="group">
                            <button class="btn btn-primary btn-sm mx-2" type="button" @click="handleEditSubmit">
                                Salvar
                            </button>
                            <button class="btn btn-danger btn-sm" type="button" @click="handleEditCancel">
                                Cancelar
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div v-if="activeeditSupplierModal" class="modal-backdrop fade show"></div>
</template>
  
<script>

import axios from "axios";
import { mask } from 'vue-the-mask';
import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';
import { validateCnpj } from './../../Utils/validateCnpj';
import { validateCpf } from './../../Utils/validateCpf';
import { validateCep } from './../../Utils/validateCep';

export default {
    directives: {
        directives: { mask }
    },
    data() {
        return {
            path: "https://localhost:7253/supplier",
            activeAddSupplierModal: false,
            addSupplierForm: {
                id: "",
                cnpj_cpf: "",
                name: "",
                email: "",
                cep: "",
                pf: false,
                rg: "",
                birth_data: "",
            },
            activeeditSupplierModal: false,
            editSupplierForm: {
                id: "",
                cnpj_cpf: "",
                name: "",
                email: "",
                cep: "",
                pf: false,
                rg: "",
                birth_data: "",
            },
            suppliers: [],
            message: "",
            messageError: "",
            showMessage: false,
            showMessageError: false,
            currentPage: 1,
            itemsPerPage: 5,
            filter: {
                filterCpfCnpj: "",
                filterName: "",
            }
        };
    },
    components: {
    },
    computed: {
        totalPages() {
            return Math.ceil(this.suppliers.length / this.itemsPerPage);
        },
        paginatedSupplies() {
            const startIndex = (this.currentPage - 1) * this.itemsPerPage;
            const endIndex = startIndex + this.itemsPerPage;
            return this.suppliers.slice(startIndex, endIndex);
        },
        pages() {
            const pagesArray = [];
            for (let i = 1; i <= this.totalPages; i++) {
                pagesArray.push(i);
            }
            return pagesArray;
        }
    },
    methods: {
        async addSupplier(payload) {
            try {
                var resultDocument = await this.validateRegiter(payload.cnpj_cpf)
                var resultCep = await validateCep(payload.cep)
                if (!resultCep) toast.warning("CEP inválido!", { autoClose: 1000, });

                if (resultCep && resultDocument) {
                    console.log(this.path)
                    console.log(payload)
                    const response = await axios.post(this.path, payload);

                    toast.success(response.data, { autoClose: 1000 });
                    this.toggleaddSupplierModal();
                    this.initForm();
                    this.getSuppliers();
                }
            } catch (error) {
                toast.warning("Documento já cadastrado!", { autoClose: 1000 });
                console.error(error);
            }
        },
        changePage(page) {
            if (page >= 1 && page <= this.totalPages) {
                this.currentPage = page;
            }
        },
        applyFilter() {
            if (this.filter.filterName === "" && this.filter.filterCpfCnpj === "") {
                this.getSuppliers()
            }
            const filteredSuppliers = this.suppliers.filter(item => {
                const matchesFilterName = item.name.includes(this.filter.filterName);
                const matchesFilterCpfCnpj = item.cnpj_cpf.includes(this.filter.filterCpfCnpj);

                return matchesFilterName && matchesFilterCpfCnpj;
            });

            this.suppliers = filteredSuppliers;
        },
        async validateRegiter(document) {
            const cnpjLength = 14;
            const cpfLength = 11;
            const cleanedCnpj = document.replace(/[^\d]/g, '');
            const length = cleanedCnpj.length;

            if (length === cnpjLength && !validateCnpj(document)) {
                toast.warning("CNPJ Inválido!", { autoClose: 1000, });
                return false;
            } else if (length === cpfLength && !validateCpf(document)) {
                toast.warning("CPF Inválido!", { autoClose: 1000, });
                return false;
            } else if (length < 11) {
                toast.warning("Documento Inválido!", { autoClose: 1000, });
                return false;
            }
            return true;
        },
        toggleIsPessoaFisica(type) {
            if (type === 'add') {
                this.addSupplierForm.pf = !this.addSupplierForm.pf;
            } else if (type === 'edit') {
                this.editSupplierForm.pf = !this.editSupplierForm.pf;
                if (!this.editSupplierForm.pf) {
                    this.editSupplierForm.pf = false,
                        this.editSupplierForm.rg = "",
                        this.editSupplierForm.birth_data = ""

                    this.addSupplierForm.pf = false,
                        this.addSupplierForm.rg = "",
                        this.addSupplierForm.birth_data = ""
                }
            }
        },
        getSuppliers() {
            axios
                .get(this.path)
                .then((res) => {
                    this.suppliers = res.data;
                })
                .catch((error) => {
                    toast.error("Erro ao carregar dados", { autoClose: 1000, });
                    console.error(error);
                });
        },
        handleAddReset() {
            this.initForm();
        },
        generateUniqueId() {
            const timestamp = Date.now();
            const randomNumber = Math.floor(Math.random() * 100000);

            const uniqueId = `${timestamp}${randomNumber}`;

            return parseInt(uniqueId, 10); // Converte para número inteiro
        },
        handleAddSubmit() {
            const payload = {
                cnpj_cpf: this.addSupplierForm.cnpj_cpf,
                name: this.addSupplierForm.name,
                email: this.addSupplierForm.email,
                cep: this.addSupplierForm.cep,
                pf: this.addSupplierForm.pf,
                rg: this.addSupplierForm.rg,
                birth_data: this.addSupplierForm.birth_data,
            };
            this.addSupplier(payload);
        },
        initForm() {
            this.hasValidateCep = false;
            this.addSupplierForm.pf = false;
            this.addSupplierForm.cnpj_cpf = "",
            this.addSupplierForm.name = "",
            this.addSupplierForm.email = "",
            this.addSupplierForm.cep = "",
            this.addSupplierForm.rg = "",
            this.addSupplierForm.birth_data = "",

            this.editSupplierForm.cnpj_cpf = "",
            this.editSupplierForm.pf = false,
            this.editSupplierForm.name = "",
            this.editSupplierForm.email = "",
            this.editSupplierForm.cep = "",
            this.editSupplierForm.rg = "",
            this.editSupplierForm.birth_data = "";
        },
        toCompany() {
            this.$router.push('/');
        },
        toggleaddSupplierModal() {
            const body = document.querySelector("body");
            this.activeAddSupplierModal = !this.activeAddSupplierModal;
            if (this.activeAddSupplierModal) {
                body.classList.add("modal-open");
            } else {
                body.classList.remove("modal-open");
            }
        },
        toggleeditSupplierModal(supplier) {
            if (supplier) {
                this.editSupplierForm = supplier;
            }
            const body = document.querySelector("body");
            this.activeeditSupplierModal = !this.activeeditSupplierModal;
            if (this.activeeditSupplierModal) {
                body.classList.add("modal-open");
            } else {
                body.classList.remove("modal-open");
            }
        },
        handleEditSubmit() {
            this.toggleeditSupplierModal(null);
            const payload = {
                id: this.editSupplierForm.id,
                cnpj_cpf: this.editSupplierForm.cnpj_cpf,
                name: this.editSupplierForm.name,
                email: this.editSupplierForm.email,
                cep: this.editSupplierForm.cep,
                pf: this.editSupplierForm.pf,
                rg: this.editSupplierForm.rg,
                birth_data: this.editSupplierForm.birth_data
            };
            this.updateSupplier(payload);
        },
        updateSupplier(payload) {
            axios.put(this.path, payload)
                .then((res) => {
                    this.getSuppliers();
                    toast.success(res.data, { autoClose: 1000, });
                })
                .catch((error) => {
                    toast.error("Erro ao atualizar fornecedor", { autoClose: 1000, });
                    console.error(error);
                    this.getSuppliers();
                });
        },
        handleEditCancel() {
            this.toggleeditSupplierModal(null);
            this.initForm();
            this.getSuppliers();
        },
        handleDeleteSupplier(supplierId) {
            var data = {
                id: supplierId,
                cnpj_cpf: "",
                name: "",
                email: "",
                cep: "",
                pf: false,
                rg: "",
                birth_data: ""
            }
            this.removeSupplier(data);
        },
        removeSupplier(supplier) {
            const headers = {
                'Content-Type': 'application/json'
            };
            axios.delete(this.path, {
                headers,
                data: JSON.stringify(supplier)
            })
                .then((res) => {
                    toast.success(res.data, { autoClose: 1000, });
                    this.getSuppliers();
                })
                .catch((error) => {
                    toast.success("Erro ao deletar empresa", { autoClose: 1000, });
                    this.getSuppliers();
                });
        },
    },
    created() {
        this.getSuppliers();
    },
};
</script>
  