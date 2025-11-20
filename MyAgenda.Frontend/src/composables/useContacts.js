import { ref } from "vue";
import api from "../api/http";

export function useContacts() {
  const contacts = ref([]);

  const loadContacts = async () => {
    try {
      const res = await api.get("/contacts");
      contacts.value = res.data;
    } catch (error) {
      console.error("Erro ao carregar contatos:", error);
    }
  };

  const createContact = async (contact) => {
    try {
      await api.post("/contacts", contact);
      await loadContacts();
    } catch (error) {
      console.error("Erro ao criar contato:", error);
    }
  };

  const updateContact = async (id, contact) => {
    try {
      await api.put(`/contacts/${id}`, contact);
      await loadContacts();
    } catch (error) {
      console.error("Erro ao atualizar contato:", error);
    }
  };

  const deleteContact = async (id) => {
    try {
      await api.delete(`/contacts/${id}`);
      await loadContacts();
    } catch (error) {
      console.error("Erro ao deletar contato:", error);
    }
  };

  return {
    contacts,
    loadContacts,
    createContact,
    updateContact,
    deleteContact,
  };
}