
typedef struct word{
	char palavra[30];
	int tamanho;
} word_t;

__kernel void contaPalavras( 
	__global word_t* sen,
	__global word_t* ret
	) 
	{ 
		int id = get_global_id(0);

		bool ok1 = false;
		bool ok2 = false;
		int cont = 0;
		int size = sen[id].tamanho;
		if(ret[0].tamanho==0){
			for(int i=0;i<size-1;i++){
				ret[id].palavra[i]=sen[id].palavra[i];
			}
			ret[id].tamanho = 1;
		}else{
			for(int i=0; i<sizeof(ret)/sizeof(word_t); i++){
				for(int j=0; j<sen[id].tamanho-1;j++){
					if(ret[i].palavra[j]==sen[id].palavra[j]){
						if(sen[id].palavra[j+1]=='\0'){
							ret[i].tamanho+=1;
							ok1=true;
							ok2=true;
						}
					}else{
						break;
					}
				}
				if(ok1==false){
					if(ret[i].tamanho==0){
						break;
					}else{
						cont++;
					}
				}else{
					ok1=false;
					break;
				}
			}
			if(ok2==false){
				for(int i=0;i<size-1;i++){
					ret[cont].palavra[i]=sen[id].palavra[i];
				}
				ret[cont].tamanho = 1;
			}else{
				ok2=false;
			}
		}
	}
	
