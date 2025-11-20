import api from "./http";

/**
 * GET ALL CONTACS
 */
export const getContacts = async () => {
  return api.get("/contacts");
};

/**
 * CREATE A NEW CONTACT
 * @param {Object} data - { name, email, phone }
 */
export const createContact = async (data) => {
  return api.post("/contacts", data);
};

/**
 * UPDATE A CONTACT
 * @param {number|string} id - ID do contato
 * @param {Object} data - { name, email, phone }
 */
export const updateContact = async (id, data) => {
  return api.put(`/contacts/${id}`, data);
};

/**
 * DELETE A CONTACT
 * @param {number|string} id
 */
export const deleteContact = async (id) => {
  return api.delete(`/contacts/${id}`);
};