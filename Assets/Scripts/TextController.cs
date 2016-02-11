using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update ()
	{
		print (myState);
		if (myState == States.cell) {
			state_cell ();
		} else if (myState == States.sheets_0) {
			state_sheets_0 ();
		} else if (myState == States.mirror) {
			state_mirror ();
		} else if (myState == States.lock_0) {
			state_lock_0 ();
		} else if (myState == States.sheets_1) {
			state_sheets_1 ();
		} else if (myState == States.cell_mirror) {
			state_cell_mirror ();
		} else if (myState == States.lock_1) {
			state_lock_1 ();
		} else if (myState == States.freedom) {
			state_freedom ();
		}
	
	}

	void state_cell ()
	{
		text.text = "Você está em uma cela da prisão, e você quer escapar. Existem alguns lençois velhos e sujos na cama, um bancada " +
					"com uma pia com a torneira enferrujada e pingando, um espelho na parede e a grade está trancada pelo lado de fora.\n\n" +
					"Pressione 'L' para ver os Lençois, 'E' para ver o Espelho e 'F' para ver a Fechadura";

		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.sheets_0;
		} else if (Input.GetKeyDown (KeyCode.E)) {
			myState = States.mirror;
		} else if (Input.GetKeyDown (KeyCode.F)) {
			myState = States.lock_0;
		} 
	}


	void state_sheets_0 ()
	{
		text.text = "Você não pode acreditar que você dorme nesse chiqueiro. Com certeza está na hora de alguém trocar os lençois. " +
		  			"Os prazeres de uma vida na prisão, eu acho!\n\n" +
					"Pressione 'V' para voltar para a cela";

		if (Input.GetKeyDown (KeyCode.V)) {
			myState = States.cell;
		} 
	}

	void state_sheets_1 ()
	{
		text.text = "Segurar um espelho na mão não faz com que os lençois fiquem mais bonitos.\n\n" +
					"Pressione 'V' para voltar para a cela";

		if (Input.GetKeyDown (KeyCode.V)) {
			myState = States.cell_mirror;
		} 
	}

	void state_mirror ()
	{
		text.text = "O velho espelho está sujo, você passa o braço para limpa-lo e nota que ele está meio solto.\n\n " +
					"Pressione 'P' para pegar o Espelho, 'V' para voltar para a cela";

		if (Input.GetKeyDown (KeyCode.V)) {
			myState = States.cell;
		} else if (Input.GetKeyDown (KeyCode.P)) {
			myState = States.cell_mirror;
		}
	}

	void state_cell_mirror ()
	{
		text.text = "Você está com o espelho na mão, vendo a marca que ele deixou na parede, você continua pensando em escapar. " +
					"Existem alguns lençois sujos na cama e aquela grade ainda está lhe impedindo de ir embora.\n\n" +
					"Pressione 'L' para ver os Lençois, 'F' para ver a Fechadura";

		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.sheets_1;
		} else if (Input.GetKeyDown (KeyCode.F)) {
			myState = States.lock_1;
		}
	}

	void state_lock_0 ()
	{
		text.text = "Esta é uma fechadura com botões. Você não sabe qual a combinação, mas você " +
		  			"já viu o guarda apertar os botões com a mão engordurada de comida. " +
		  			"Se pelo menos você conseguisse ver aonde está a sujeira da mão do guarda, " +
		  			"talvez pudesse te ajudar.\n\n" +
					"Pressione 'V' para voltar para a cela";

		if (Input.GetKeyDown (KeyCode.V)) {
			myState = States.cell;
		}
	}

	void state_lock_1 ()
	{
		text.text = "Você olha para os lados pelas barras e não vê nenhum guarda vindo. " +
		  			"Você passa o espelho através da grade com cuidado e então pode ver a fechadura. " +
		  			"Agora você vê claramente as marcas deixadas nos botões. Você pressiona os botões marcados " +
		  			"e escuta um click" +
		  			"talvez pudesse te ajudar.\n\n" +
					"Pressione 'A' para Abrir ou 'V' para voltar para a cela";

		if (Input.GetKeyDown (KeyCode.V)) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown (KeyCode.A)) {
			myState = States.freedom;
		}
	}

	void state_freedom ()
	{
		text.text = "Parabéns, você fugiu!\n\n" +
					"Pressione P para jogar novamente";

		if (Input.GetKeyDown(KeyCode.P)){
			myState = States.cell;
		}
	}
}
