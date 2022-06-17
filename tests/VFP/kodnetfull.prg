
#define FORMAT_MESSAGE_ALLOCATE_BUFFER 0x00000100
#define FORMAT_MESSAGE_IGNORE_INSERTS 0x00000200
#define FORMAT_MESSAGE_FROM_SYSTEM 0x00001000

LOCAL localPath
localPath= JUSTPATH(SYS(16))
IF _vfp.StartMode!=0
	localpath= JUSTPATH(_vfp.ServerName)
ENDIF 

? 'LocalPath: ' + localPath

if(TYPE("_screen.dotnet4full")=="O" and !isnull(_screen.dotnet4full))
	if(TYPE("_screen.dotnet4fullmanager")=="O" and !isnull(_screen.dotnet4fullmanager))
		RETURN 
	ENDIF 
ENDIF 
SET PATH TO (m.localpath) additive
SET PATH TO (m.localpath+"/lib") additive
*DO wwDotnet4

* Programa creado por Michael Su�rez para interactura con .NET desde VFP ...
LOCAL dotnet4full

dotnet4full = CREATEOBJECT("jxshell_dotnet4")
dotnet4full.path = m.localpath+"\"
dotnet4full.libPath = dotnet4full.path + "lib\"


* Ahora se debe cargar el ensamblado encargado de todo ...
dotnet4full.initClr()
LOCAL manager
manager = dotnet4full.getClr()

_screen.AddProperty("dotnet4fullManager", m.dotnet4full)
_screen.AddProperty("__dotnet4full", m.manager)
_screen.AddProperty("__dotnetv", CREATEOBJECT("kodnetfull"))
_screen.AddProperty("dotnet4full", m.manager)
_screen.AddProperty("kodnetfull", m.manager)
_screen.AddProperty("kodnetfullManager", m.dotnet4full)
RETURN manager

DEFINE CLASS jxshell_dotnet4ui as session
	dataSession=1
	anchorStyles = null
	_anchorStyles = null
	
	FUNCTION anchorStyles_access()
		if(ISNULL(this._anchorStyles))
			this._anchorStyles= _Screen.dotnet4full.getStaticWrapper("System.Windows.Forms.AnchorStyles")
		ENDIF 
		RETURN this._anchorStyles
	ENDFUNC 
ENDDEFINE 

* THIS CLASSES (kodnet, kodnetWrapper) ARE FOR A EXPERIMENT TRYING TO INCREASE PERFORMANCE IN LOADING TIME
* AND REALLY CAN INCREASE PERFORMANCE ON LOADING TIME, BUT DECREASES ON INVOKING METHODS
DEFINE CLASS kodnetWrapper as session  
	__helper= null 
	___obj= null
	FUNCTION init(helper, obj)
		this.__helper= m.helper
		this.___obj= obj
		this.init_class()
	ENDFUNC 
	FUNCTION init_class()
	ENDFUNC 

ENDDEFINE 

DEFINE CLASS kodnetfull as Custom 

	helpers= null
	tmpfolder= null 
	FUNCTION init()
		LOCAL folder 
		this.helpers= CREATEOBJECT('collection')
		folder= GETENV("APPDATA")
		folder= ADDBS(m.folder) + "kodnetfull"
		IF !DIRECTORY(m.folder)
			MKDIR (m.folder )
		ENDIF 
		folder= ADDBS(m.folder) + "tmp"
		IF !DIRECTORY(m.folder)
			MKDIR (m.folder )
		ENDIF 
		this.tmpfolder= m.folder
	ENDFUNC 
	
	FUNCTION compile(ast, typeD)
		LOCAL file , val 
		val= null 
		file= ADDBS(this.tmpfolder) + SYS(2015) + ".prg"
		TRY 
			STRTOFILE(m.ast.code, m.file) 
			SET procedure TO (m.file) ADDITIVE 
			val= CREATEOBJECT(m.ast.staticName, m.typeD)
		CATCH TO ex 
			error  m.ex.message
		FINALLY 
			IF FILE(m.file)
				DELETE FILE m.file
			ENDIF 
		ENDTRY 
		RETURN m.val 
	
	ENDFUNC 
	
	FUNCTION create(helper)
		RETURN CREATEOBJECT("kodnetfullWrapper", m.helper)
	ENDFUNC 
	
	FUNCTION getStaticWrapper(type)
		LOCAL typeD, helper
		typeD= NULL 
		helper= null 
		TRY 
			helper= this.helpers[m.type]
		CATCH TO er 
		ENDTRY
		IF ISNULL(m.helper)
			typeD= _screen.__dotnet4full.loadTypeNoCompile(m.type)
			helper= _screen.__dotnet4full.vfpHelper(m.typeD)
			
			* compile class 
			ast= m.helper.compile()
			helper= this.compile(m.ast, m.helper)
			* helper= this.create(m.helper)
			this.helpers.Add(m.helper, m.type)
		ENDIF 
		
		RETURN m.helper
		
	ENDFUNC 

ENDDEFINE 

DEFINE CLASS jxshell_event as Session
	target=null
	FUNCTION init(target,method)
		IF !(m.target.baseclass == "Form")
			this.target= m.target
			ADDPROPERTY(this.target, "_event_" + m.method, this)
		ENDIF 
		BINDEVENT(this, "invoke", m.target, m.method)
	ENDFUNC 
	FUNCTION invoke()
		LPARAMETERS e1,e2,e3
	ENDFUNC 
	FUNCTION destroy()
		this.target= null
	ENDFUNC 

ENDDEFINE 

DEFINE CLASS jxshell_dotnet4 as Session
	
	dataSession=1
	manager = null
	path = ""
	libPath = ""
	wwDotnet = null
	API = null
	ui= null
	initedUi= .f.
	
	FUNCTION init()
		this.API= CREATEOBJECT("JXSHELLDOTNET4_WIN32API")
		this.ui = CREATEOBJECT("jxshell_dotnet4ui")
	ENDFUNC 
	
	FUNCTION getClr()
		RETURN this.manager
	ENDFUNC 
	
	FUNCTION setClassLoadingMode(mode)
		* 0 - compile with c#
		* 1 - compile with VFP 
		IF mode == 0
			_screen.dotnet4full= _screen.__dotnet4full 
			_screen.kodnetfull= _screen.__dotnet4full 
		ENDIF 
		IF mode == 1
			_screen.dotnet4full= _screen.__dotnetv 
			_screen.kodnetfull= _screen.__dotnetv
		ENDIF 
		
	ENDFUNC 
	FUNCTION getWrapped(obj)
		LOCAL cls 
		IF vartype(m.obj)=='O'
			cls=_screen.__dotnetv.getStaticWrapper(m.obj.name)
			obj= m.cls.___create(m.obj.value)
		ENDIF 
		RETURN obj 
	ENDFUNC 
	FUNCTION getUnWrapped(obj)
		IF vartype(m.obj) == "O"
			RETURN m.obj.__obj
		ENDIF 
		RETURN obj 
	ENDFUNC 
	FUNCTION initUi()
		if(!this.initedUi)
			_screen.dotnet4full.loadAssemblyPartialName("System")
			_screen.dotnet4full.loadAssemblyPartialName("System.Drawing")
			_screen.dotnet4full.loadAssemblyPartialName("System.Windows.Forms")
			
			_screen.dotnet4full.loadManyTypes("System.Drawing.Font-System.EventHandler-System.EventArgs-System.Windows.Forms.Form-System.Windows.Forms.Application-System.Windows.Forms.Button-System.Windows.Forms.ComboBox-"+;
				"System.Windows.Forms.TextBox-System.Windows.Forms.Control-System.Drawing.Color-System.Drawing.Bitmap"+;
				"-System.Drawing.PointF-System.Drawing.RectangleF-System.Drawing.Point-System.Drawing.Rectangle")
				
			LOCAL app
			app= _screen.dotnet4full.getStaticWrapper("System.Windows.Forms.Application")
			app.enableVisualStyles()
			
			this.initedUi= .t.
		ENDIF 
	ENDFUNC 
	
	FUNCTION createEventHandler(object, method, className)
		if(EMPTY(m.className))
			className = "System.EventHandler" 
		ENDIF 
		LOCAL ev, even
		ev = _Screen.dotnet4full.getStaticWrapper(m.className)
		even= CREATEOBJECT("jxshell_event", m.object, m.method)
		RETURN ev.construct(m.even, "invoke")
		*RETURN ev.construct(m.object, m.method)
		
	ENDFUNC 


	FUNCTION rgbtoArgb
		LPARAMETERS tnColor, tnAlpha
	 	Local argb, red, green, blue
	 	blue = Bitrshift(Bitand(tnColor, 0x00FF0000), 16)
	 	green = Bitrshift(Bitand(tnColor, 0x0000FF00), 8)
	 	red = Bitand(tnColor, 0x000000FF)
	 	argb = blue + Bitlshift(green, 8) + Bitlshift(red, 16)
	 	If Vartype(tnAlpha) = 'N'
	 		argb = argb + Bitlshift(Bitand(tnAlpha, 0xFF), 24)
	 	Else
	 		argb = argb + Bitlshift(255, 24)
	 	ENDIF
	 	RETURN ARGB
	ENDFUNC 	
	
	FUNCTION initClr()
		if(!ISNULL(this.manager))
			RETURN 
		ENDIF 
		LOCAL dotnet4fullFile, er, er1
		dotnet4fullFile = this.libpath + "jxshell.dotnet4.dll"

		try
			*this.wwDotnet = CREATEOBJECT("wwDotNetBridge", "v4",.f.)
			*this.wwDotnet.loadAssembly(m.dotnet4File)
			*this.manager = this.wwdotnet.createinstance("jxshell.dotnet4.Manager")
			
			DECLARE Integer SetClrVersion IN FULLPATH("clrhost.dll") string
			SetClrVersion("v4.0.30319")
			DECLARE Integer ClrCreateInstanceFrom IN FULLPATH("clrhost.dll") string, string, string@, integer@

			lcError = SPACE(2048)
			lnSize = 0
			lnDispHandle = ClrCreateInstanceFrom(m.dotnet4fullFile,;
					"jxshell.dotnet4.Manager",@lcError,@lnSize)

			IF lnDispHandle < 1
			   error( "Unable to load CLR. " + LEFT(lcError,lnSize) )
			   RETURN NULL 
			ENDIF

			*** Turn handle into IDispatch COM object
			this.manager = SYS(3096, lnDispHandle)	

			*** Explicitly AddRef here - otherwise weird shit happens when objects are released
			SYS(3097, this.manager)

			IF ISNULL(this.manager)
				error( "No se puede inicializar el manejador de las clases CLR. Error desconocido." )
				RETURN null
			ENDIF
			
			this.manager.init()
			this.manager.setThreadedLibraryFile(this.libpath+"lib.dll")
		CATCH TO ex
			er = ex.message
			er1= ex.ErrorNo
			
		ENDTRY 
		if(!EMPTY(m.er))
			ERROR m.er1, m.er
		ENDIF 			

	ENDFUNC 
	
ENDDEFINE

DEFINE CLASS JXSHELLDOTNET4_WIN32API AS Session
	datasession =1
	
	FUNCTION init()
		* Funciones del API
		DECLARE INTEGER FormatMessage IN kernel32 as jxshelldotnet4_formatMessage;
		    INTEGER   dwFlags,;
		    integer   lpSource,;
		    INTEGER   dwMessageId,;
		    INTEGER   dwLanguageId,;
		    INTEGER @ lpBuffer,;
		    INTEGER   nSize,;
		    INTEGER   Arguments
		    
		    
		DECLARE long GetLastError IN kernel32 as jxshelldotnet4_lastError 
		
		DECLARE long SetParent IN WIN32API as jxshelldotnet4_setParent;
			LONG,LONG
			
		DECLARE long GetParent IN WIN32API as jxshelldotnet4_getParent;
			LONG
			
		DECLARE long GetForegroundWindow IN WIN32API as jxshelldotnet4_getForegroudWindow
		
	ENDFUNC 
	
	FUNCTION setParent(controlHandle, form)
		LOCAL o
		o= form
		if(TYPE("m.form")="O")
			o= form.hwnd 
		ENDIF 
		
		LOCAL ret
		ret = jxshelldotnet4_setParent(m.controlHandle, m.o)
		if(m.ret = 0)
			&& Significa que fall� ...
			ret = jxshelldotnet4_lastError ()
			IF m.ret = 0
				ERROR("Fall� asignando el objeto parent al control. Error desconocido.")
				RETURN .f.
			else	
				
				LOCAL flags
				flags = BITOr(FORMAT_MESSAGE_ALLOCATE_BUFFER ,;
					 FORMAT_MESSAGE_FROM_SYSTEM ,FORMAT_MESSAGE_IGNORE_INSERTS)
				
				LOCAL message, len
				message = 0 &&SPACE(4096)
				len = jxshelldotnet4_formatMessage(m.flags, 0, m.ret, 0, @message, 0, 0)
				ERROR("Fall� asignando el objeto parent al control. " + SYS(2600,m.message,m.len))
				RETURN .f.
				
				
			ENDIF 
			
			
		ENDIF 
	ENDFUNC 
	
ENDDEFINE 