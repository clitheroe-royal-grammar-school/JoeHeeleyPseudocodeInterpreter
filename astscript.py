import os

curr_path = os.getcwd()
def automateAST(output_dir,base,types):
    #boiler is just the using statements and the namespace declaration
    boiler = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Text;\nusing System.Threading.Tasks;\nnamespace JoePlusPlus{\n"
    path = output_dir + '/' + base + '.cs'
    with open(path,'w') as f:
        #abstract class
        f.write(boiler)
        f.write("\tabstract class "+base+"{\n");
        f.write("\t\tpublic abstract T Accept<T>(Visitor<T> vis);\n")
        f.write("\t}\n")
        #visitor interface
        f.write("\tinterface Visitor<T>{\n")
        for asttype in types.keys():
            display_type = base + asttype
            f.write("\t\tT Visit"+display_type+"("+display_type+" "+base.lower()+'_'+asttype.lower()+");\n")
        f.write("\t}\n")
        for asttype in types.keys():
            display_type = base + asttype
            raw_args = types[asttype]
            args = raw_args.split(',')
            args_dict = {}
            for arg in args:
                temp = arg.split(' ')
                args_dict[temp[1]] = temp[0]
            f.write("class "+display_type+":"+base+"{\n");
            #field declarations
            for arg in args_dict.keys():
                f.write("\tpublic "+args_dict[arg]+" "+arg+";\n")
            #constructor declaration
            f.write("\tpublic "+display_type+"("+raw_args+"){\n")
            for arg in args_dict.keys():
                f.write("\t\tthis."+arg+"="+arg+";\n")
            f.write("\t\t}\n")
            #accept override
            f.write("\tpublic override T Accept<T>(Visitor<T> vis){\n")
            f.write("\t\treturn vis.Visit"+display_type+"(this);\n");
            f.write("\t}\n\t}\n")
        f.write("}")


print(curr_path)
automateAST(curr_path,"Expr",{"Binary":"Expr left,Token op,Expr right",
                            "Grouping":"Expr expression",
                            "Literal":"object value",
                            "Unary": "Token op,Expr right"})
automateAST(curr_path,"Stmt",{"Expression":"Expr expression",
                             "Output":"Expr expression"})

