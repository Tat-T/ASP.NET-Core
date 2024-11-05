const headers = ['Name', 'Sound', 'Save'];
 const headerRow = document.getElementById('tableHeaders');
 
 headerRow.innerHTML = headers.map(header => `<th>${header}</th>`).join('');

 // Пример данных для таблицы
 const animals = [
     { name: 'Cat', sound: 'Meow' },
     { name: 'Dog', sound: 'Woof' },
 ];

 const animalTable = document.getElementById('animalTable');
 animalTable.innerHTML = animals.map(animal => `
     <tr>
         <td>${animal.name}</td>
         <td>${animal.sound}</td>
         <td><button class="btn btn-primary" onclick="saveAnimal('${animal.name}')">Download</button></td>
     </tr>
 `).join('');
// Сохранение конкретного животного
function saveAnimal(animalName) {
    const animal = { name: animalName };
    fetch('/api/Animal/SaveAnimal', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(animal)
    })
    .then(response => {
        if (response.ok) {
            alert(`Animal ${animalName} saved successfully!`);
        } else {
            alert(`Failed to save ${animalName}.`);
        }
    })
    .catch(error => console.error('Error:', error));
}

// Сохранение всех животных в заданном формате (JSON или XML)
function saveAnimals(format) {
    fetch(`/api/Animal/output?format=${format}`, {
        method: 'POST'
    })
    .then(response => {
        if (response.ok) {
            alert(`Animals saved as ${format.toUpperCase()} successfully!`);
        } else {
            alert(`Failed to save animals as ${format.toUpperCase()}.`);
        }
    })
    .catch(error => console.error('Error:', error));
}