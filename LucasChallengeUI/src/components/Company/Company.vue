<template>
  <div class="container">
    <div class="row">
      <div class="col-sm-10">
        <div class="d-flex justify-content-between align-items-center">
          <h1>Empresas</h1>
          <button class="btn btn-secondary btn-sm" type="button" @click="toSupplier">
            Fornecedores
          </button>
        </div>
        <hr />
        <br /><br />
        <button class="btn btn-success btn-sm" type="button" @click="toggleaddCompanyModal">
          Adicionar Empresa
        </button>
        <br /><br />

        <div class="d-flex flex-column align-items-center">
          <table class="table table-hover">
            <!-- Cabeçalho da tabela -->
            <thead>
              <tr>
                <th scope="col">CNPJ</th>
                <th scope="col">Nome fantasia</th>
                <th scope="col">Cep</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              <!-- Renderiza as linhas da tabela baseadas na página atual e quantidade de itens por página -->
              <tr v-for="(company, index) in paginatedCompanies" :key="index">
                <td>{{ company.cnpj }}</td>
                <td>{{ company.fantasyName }}</td>
                <td>{{ company.cep }}</td>
                <td>
                  <div class="btn-group" role="group">
                    <button class="btn btn-warning btn-sm mx-2" type="button" @click="toggleeditCompanyModal(company)">
                      Atualizar
                    </button>
                    <button class="btn btn-danger btn-sm" type="button" @click="() => handleDeleteCompany(company.id)">
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
              <li class="page-item" v-for="page in pages" :key="page" :class="{ 'active': page === currentPage }">
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
  <!-- add new company modal -->
  <div ref="addCompanyModal" :class="{ show: activeAddCompanyModal, 'd-block': activeAddCompanyModal }" class="modal fade"
    role="dialog" tabindex="-1">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Adicionar nova Empresa</h5>
          <button aria-label="Close" class="close" data-dismiss="modal" type="button" @click="toggleaddCompanyModal">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form>
            <div class="mb-3">
              <label class="form-label" for="addCompanyCNPJ">CNPJ:</label>
              <input id="addCompanyCNPJ" v-model="addCompanyForm.cnpj" class="form-control" placeholder="Digite seu CNPJ"
                type="text" v-mask="'##.###.###/####-##'" />
            </div>
            <div class="mb-3">
              <label class="form-label" for="addCompanyFantasyName">Nome Fantasia:</label>
              <input id="addCompanyFantasyName" v-model="addCompanyForm.fantasyName" class="form-control"
                placeholder="Digite o Nome Fantasia" type="text" />
            </div>
            <div class="mb-3">
              <label class="form-label" for="addCompanyCep">Cep</label>
              <input id="addCompanyCep" v-model="addCompanyForm.cep" class="form-control" placeholder="Digite o CEP"
                type="text" v-mask="'#####-###'" />
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
  <div v-if="activeAddCompanyModal" class="modal-backdrop fade show"></div>
  <!-- edit company modal -->
  <div ref="editCompanyModal" :class="{ show: activeeditCompanyModal, 'd-block': activeeditCompanyModal }"
    class="modal fade" role="dialog" tabindex="-1">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Atualizar Empresa</h5>
          <button aria-label="Close" class="close" data-dismiss="modal" type="button" @click="toggleeditCompanyModal">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form>
            <div class="mb-3">
              <label class="form-label" for="editCompanyCNPJ">CNPJ:</label>
              <input id="editCompanyCNPJ" v-model="editCompanyForm.cnpj" class="form-control"
                placeholder="Digite seu CNPJ" type="text" v-mask="'##.###.###/####-##'">
            </div>
            <div class="mb-3">
              <label class="form-label" for="editFantasyName">Nome Fantasia:</label>
              <input id="editFantasyName" v-model="editCompanyForm.fantasyName" class="form-control"
                placeholder="Digite o Nome Fantasia" type="text">
            </div>
            <div class="mb-3">
              <label class="form-label" for="editCep">CEP:</label>
              <input id="editCep" v-model="editCompanyForm.cep" class="form-control" placeholder="Digite o CEP"
                type="text" v-mask="'#####-###'">
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
  <div v-if="activeeditCompanyModal" class="modal-backdrop fade show"></div>
</template>

<script>

import axios from "axios";
import { mask } from 'vue-the-mask';
import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';

export default {
  directives: {
    directives: { mask }
  },
  data() {
    return {
      activeAddCompanyModal: false,
      addCompanyForm: {
        id: "",
        cnpj: "",
        fantasyName: "",
        cep: "",
      },
      activeeditCompanyModal: false,
      editCompanyForm: {
        id: "",
        cnpj: "",
        fantasyName: "",
        cep: "",
      },
      companies: [],
      message: "",
      messageError: "",
      showMessage: false,
      showMessageError: false,
      currentPage: 1,
      itemsPerPage: 5,
    };
  },
  components: {
  },
  computed: {
    totalPages() {
      return Math.ceil(this.companies.length / this.itemsPerPage);
    },
    paginatedCompanies() {
      const startIndex = (this.currentPage - 1) * this.itemsPerPage;
      const endIndex = startIndex + this.itemsPerPage;
      return this.companies.slice(startIndex, endIndex);
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

    addCompany(payload) {
      const path = "https://localhost:7253/company";
      axios
        .post(path, payload)
        .then((res) => {
          toast.success(res.data, { autoClose: 1000, });
          this.getCompanies();
        })
        .catch((error) => {
          toast.error("Erro ao adicionar Empresa", { autoClose: 1000, });
          console.log(error);
          this.getCompanies();
        });
    },

    changePage(page) {
      if (page >= 1 && page <= this.totalPages) {
        this.currentPage = page;
      }
    },
    getCompanies() {
      const path = "https://localhost:7253/company";
      axios
        .get(path)
        .then((res) => {
          this.companies = res.data;
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
      this.toggleaddCompanyModal();
      const payload = {
        id: this.generateUniqueId(),
        cnpj: this.addCompanyForm.cnpj,
        fantasyName: this.addCompanyForm.fantasyName,
        cep: this.addCompanyForm.cep,
      };
      this.addCompany(payload);
      this.initForm();
    },
    initForm() {
      this.addCompanyForm.cep = "";
      this.addCompanyForm.cnpj = "";
      this.addCompanyForm.fantasyName = [];

      this.editCompanyForm.id = "";
      this.editCompanyForm.cep = "";
      this.editCompanyForm.cnpj = "";
      this.editCompanyForm.fantasyName = "";
    },
    toSupplier() {
      this.$router.push('/supplier');
    },
    toggleaddCompanyModal() {
      const body = document.querySelector("body");
      this.activeAddCompanyModal = !this.activeAddCompanyModal;
      if (this.activeAddCompanyModal) {
        body.classList.add("modal-open");
      } else {
        body.classList.remove("modal-open");
      }
    },
    toggleeditCompanyModal(company) {
      if (company) {
        this.editCompanyForm = company;
      }
      const body = document.querySelector("body");
      this.activeeditCompanyModal = !this.activeeditCompanyModal;
      if (this.activeeditCompanyModal) {
        body.classList.add("modal-open");
      } else {
        body.classList.remove("modal-open");
      }
    },
    handleEditSubmit() {
      this.toggleeditCompanyModal(null);
      const payload = {
        id: this.editCompanyForm.id,
        cnpj: this.editCompanyForm.cnpj,
        fantasyName: this.editCompanyForm.fantasyName,
        cep: this.editCompanyForm.cep,
      };
      this.updateCompany(payload);
    },
    updateCompany(payload) {
      const path = `https://localhost:7253/company`;
      axios.put(path, payload)
        .then((res) => {
          this.getCompanies();
          toast.success(res.data, { autoClose: 1000, });
        })
        .catch((error) => {
          toast.error("Erro ao atualizar empresa", { autoClose: 1000, });
          console.error(error);
          this.getCompanies();
        });
    },
    handleEditCancel() {
      this.toggleeditCompanyModal(null);
      this.initForm();
      this.getCompanies(); // why?
    },
    handleDeleteCompany(companyID) {
      var data = {
        id: companyID,
        cnpj: "",
        fantasyName: "",
        cep: ""
      }
      this.removeCompany(data);
    },
    removeCompany(company) {
      const path = `https://localhost:7253/company`;  // URL para a requisição DELETE (sem o ID)

      // Adicionamos um cabeçalho personalizado para indicar que estamos enviando um corpo JSON
      const headers = {
        'Content-Type': 'application/json'
      };

      // Enviando o objeto company como uma string JSON no corpo
      axios.delete(path, {
        headers,
        data: JSON.stringify(company)
      })
        .then((res) => {
          toast.success(res.data, { autoClose: 1000, });
          this.getCompanies();
        })
        .catch((error) => {
          toast.success("Erro ao deletar empresa", { autoClose: 1000, });
          this.getCompanies();
        });
    },
  },
  created() {
    this.getCompanies();
  },
};
</script>
