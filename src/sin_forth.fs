#! /usr/bin/env gforth

\ sin_forth.fs
\ by Marcos Cruz (programandala.net), 2010, 2015, 2020, 2023.
\ Last modified: 20230423T1116+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ Description {{{1

\ This file is the main source file of Sin Forth, a Forth
\ cross-compiler, written in Forth with Gforth, that compiles Forth
\ programs for any model of Sinclair ZX Spectrum computer, from the ZX
\ Spectrum 16 K to the ZX Spectrum Next.

\ ==============================================================
\ Requirements {{{1

only forth definitions  decimal

warnings off
  \ This hides some warnings from the Forth Foundation Library,
  \ which is used by some Galope modules.

\ Gforth
require string.fs \ dynamic strings

\ Galope
\ http://programandala.net/en.program.galope.html

require galope/file-exists-question.fs \ `file-exists?`
require galope/minus-extension.fs      \ `-extension`
require galope/minus-suffix.fs         \ `-suffix`
require galope/n-to-str.fs             \ `n>str`
require galope/replaced.fs             \ `replaced`
require galope/s-comma.fs              \ `s,`
require galope/unslurp-file.fs         \ `unslurp-file`

warnings on

\ External tool:
\
\ bin2tap (by Metalbrain)
\   http://metalbrain.speccy.org/link-eng.htm

\ ==============================================================
\ Word lists {{{1

only forth definitions  decimal

wordlist constant compiler-wordlist
  \ The compiler word list.

wordlist constant assembler-wordlist
  \ The assembler-specific compiler word list.

wordlist constant target-wordlist
  \ The target word list.

: host{ ( -- )
  forth-wordlist >order ; immediate

: compiler{ ( -- )
  compiler-wordlist >order ; immediate

: assembler{ ( -- )
  assembler-wordlist >order ; immediate

: target{ ( -- )
  target-wordlist >order ; immediate

: compiler-order ( -- )
  only
  postpone target{
  postpone compiler{
  postpone assembler{
  postpone host{ ;

: compiler-definitions ( -- )
  compiler-order
  compiler-wordlist set-current ;

: target-order ( -- )
  only
  postpone compiler{
  postpone assembler{
  postpone target{ ;

: target-definitions ( -- )
  target-order
  target-wordlist set-current ;

: assembler-order ( -- )
  only
  postpone target{
  postpone compiler{
  postpone assembler{
  postpone host{ ;

: assembler-definitions ( -- )
  assembler-order
  assembler-wordlist set-current ;

: } ( -- )
  previous ; immediate

compiler-wordlist set-current

synonym assembler-definitions assembler-definitions
synonym compiler-definitions compiler-definitions
synonym compiler-order compiler-order
synonym target-definitions target-definitions
synonym target-order target-order

synonym } }
synonym assembler{ assembler{
synonym compiler{ compiler{
synonym host{ host{
synonym target{ target{

target-wordlist set-current

synonym assembler-definitions assembler-definitions
synonym compiler-definitions compiler-definitions
synonym compiler-order compiler-order
synonym target-definitions target-definitions
synonym target-order target-order

synonym } }
synonym assembler{ assembler{
synonym compiler{ compiler{
synonym host{ host{
synonym target{ target{

compiler-definitions

\ ==============================================================
\ Standard words needed during the compilation {{{1

\ Words that are not defined in the target and thus can keep their names:

synonym ( (  \ )
synonym \ \
synonym get-current get-current
synonym get-order get-order
synonym include include
synonym require require
synonym s" s"
synonym s\" s\"
synonym set-current set-current
synonym set-order set-order

\ Words that are defined in the target and thus need a "h-" prefix
\ (from "host"):

synonym h-@ @
synonym h-constant constant

\ ==============================================================
\ Target memory buffer and basic tools {{{1

$10000 constant /memory
  \ Size of the target memory: 64 KiB.

/memory buffer: memory  memory /memory erase
  \ Reserve a 64-KiB space for the target memory.

variable memory>
  \ Z80 address ($0000..$FFFF) where the target code is being compiled
  \ in the ZX Spectrum memory. Therefore it's also a pointer to the
  \ first free address in `memory`. Its initial value is
  \ the default value of `origin`.

$5E00 value origin  origin memory> !
  \ Initial and lowest target memory address where the target code is
  \ compiled.

: t-! ( x a -- )
\  cr 2dup swap . . ." t-! (latest: " latest .name ." )" \ XXX INFORMER
  memory + swap 2dup 256 mod swap c! 256 / swap 1+ c! ;
  \ Store the 16-bit value _x_ into target memory address _a_.

: t-c! ( c ca -- )
\  cr 2dup swap . . ." t-!  (latest: " latest .name ." )" \ XXX INFORMER
  memory + c! ;
  \ Store the 8-bit value _c_ into target memory address _ca_.

: t-c, ( c -- )
  memory> @ t-c! 1 memory> +! ;
  \ Compile the 8-bit value _c_ in the current target memory address
  \ pointed by `memory>` and increase this pointer accordingly.

: t-, ( x -- )
  memory> @ t-! 2 memory> +! ;
  \ Compile the 16-bit value _x_ in the current target memory address
  \ pointed by `memory>` and update this pointer accordingly.

\ ==============================================================
\ Configuration directives {{{1

\ ----------------------------------------------
\ set-origin {{{2

variable modified-origin  modified-origin off
  \ A flag to remember if `origin` was modified by `set-origin`.

: set-origin ( n -- )
  modified-origin @ abort" second `set-origin` not allowed"
  dup to origin memory> !
  modified-origin on ;

  \ doc{
  \
  \ set-origin ( a -- )
  \
  \ Set the initial target memory address _a_ from which the code will
  \ be compiled. Its default value is $5E00 (24064).
  \
  \ ``set-origin`` should be used before any target code is compiled,
  \ including library modules.
  \
  \ }doc

\ ----------------------------------------------
\ boot-here {{{2

variable boot-address ( -- a )
  \ _a_ contains the target memory address where the target program
  \ must be executed. This address is called by the Sinclair BASIC
  \ loader.

$10001 constant no-boot
no-boot boot-address !
  \ Store an impossible default value into `boot-address`, in order to
  \ detect whether it has been set or not.

: no-boot? ( -- f )
  boot-address @ no-boot = ;
  \ Has `boot-address` not been set?
  \ I.e., has `boot-here` not been executed before?

: boot-here ( -- )
  memory> @ boot-address ! ;

  \ doc{
  \
  \ boot-here ( -- )
  \
  \ Mark the current address of the target program as the boot
  \ address, i.e. the address that will be executed by the Sinclair
  \ BASIC loader.
  \
  \ If ``boot-here`` is not used, the boot address will be that of the
  \ latest `:` definition.
  \
  \ }doc

variable latest-colon
  \ Target address where the latest Z80 `:` definition has been
  \ compiled.

: set-default-boot ( -- )
  latest-colon @ boot-address ! ;

\ ----------------------------------------------
\ z80-symbols {{{2

$variable z80-symbols$ ( -- a )
  \ A dynamic string variable that holds the Z80 assembly symbols, in
  \ assembly. `end-program` saves it into an output file, if it's not
  \ empty.

variable z80-symbols ( -- a ) z80-symbols on
  \ A flag. When the flag is zero, the Z80 assembly symbols are not
  \ saved during the compilation.

: n>0xstr ( n -- ca len )
  base @ >r s" 0x" rot hex n>str s+ r> base ! ;

: >z80-label ( ca1 len1 -- ca2 len2 )
  2dup s" -"  str= if 2drop s" _minus"   exit then
  2dup s" 1-" str= if 2drop s" _1_minus" exit then
  s" _store_"        s" !"  replaced
  s" _star_"         s" *"  replaced
  s" _plus_"         s" +"  replaced
  s" _comma_"        s" ,"  replaced
  s" _"              s" -"  replaced
  s" _dot_"          s" ."  replaced
  s" _slash_"        s" /"  replaced
  s" _colon_"        s" :"  replaced
  s" _semicolon_"    s" ;"  replaced
  s" _less_than_"    s" <"  replaced
  s" _equals_"       s" ="  replaced
  s" _greater_than_" s" >"  replaced
  s" _fetch_"        s" @"  replaced
  s" _backslash_"    s" \"  replaced
  s" _" -suffix
  s" _" 2swap s+
  s" _"       s" __" replaced
  ;
  \ Convert Forth name _ca1 len1_ to Z80 assembly valid label _ca2 len2_.

: (z80-symbol) ( a ca len -- )
  s" : equ " s+ rot dup >r n>0xstr s+
  s"  ; (" s+ r> n>str s+ s" )" s+ s\" \n" s+
  z80-symbols$ $+! ;
  \ Create a Z80 symbol _ca len_ for the disassembly, with the target
  \ code address _a_ as its value.

: z80-symbol ( a nt -- )
  name>string >z80-label (z80-symbol) ;
  \ Create a Z80 symbol for the disassembly, from the word name
  \ identified by _nt_ and the target code address _a_ as value.

\ ----------------------------------------------
\ z80dasm-blocks {{{2

$variable z80dasm-blocks$ ( -- a )
  \ A dynamic string variable that holds the z80dasm disassembler
  \ block definitions. `end-program` saves it into an output file, if
  \ it's not empty.

variable z80dasm-blocks ( -- a ) z80dasm-blocks on
  \ A flag. When the flag is zero, the z80dasm disassembler blocks
  \ definitions are not saved during the compilation.

: z80dasm-block {: start end
                   D: block-type D: block-name
                   unlabeled-start unlabeled-end -- :}
  block-name >z80-label s" :" s+
  unlabeled-start if s"  unlabeled " s+ then
  s"  start " start n>0xstr s+ s+
  unlabeled-end if s"  unlabeled " s+ then
  s"  end " end n>0xstr s+ s+
  s"  type " block-type s+ s+
  s\" \n" s+ z80dasm-blocks$ $+! ;
  \ Create a z80dasm disassembler block defition with the following
  \ parameters:
  \
  \ start           = start address
  \ end             = end address
  \ blocktype       = string ("code", "bytedata", "worddata" or "pointers")
  \ unlabeled-start = flag
  \ unlabeled-end   = flag

: z80dasm-cell-block ( a ca len -- )
  2>r dup 2 + s" worddata" latest name>string 2r> s+
  false true z80dasm-block ;
  \ Create a z80dasm block definition for 1-cell data space created by
  \ the latest target word definition, e.g. a variable or a constant,
  \ being _a_ its address in the target memory and _ca len_ a suffix
  \ to be added to the name of the latest target definition.

: z80dasm-char-block ( ca1 ca2 len2 -- )
  2>r dup 1+ s" bytedata" latest name>string 2r> s+
  false true z80dasm-block ;
  \ Create a z80dasm block definition for 1-character data space created by
  \ the latest target word definition, e.g. a character variable or a
  \ character constant, being _ca1_ its address in the target memory
  \ and _ca2 len2_ a suffix to be added to the name of the latest
  \ target definition.

: z80dasm-stack-block ( a len -- )
  over + s" worddata" s" data_stack" false false z80dasm-block ;
  \ Create a z80dasm block definition for the data stack, whose top
  \ (low address) is at target memory address
  \ _a_ and its length is _len_ bytes.

: z80dasm-allot-block ( len -- )
  memory> @ tuck + s" bytedata"
  base @ >r hex  s" alloted_at_" memory> @ n>str s+
         r> base !
  false false z80dasm-block ;
  \ Create a z80dasm block definition for allocated data space of
  \ _len_ bytes.

\ ==============================================================
\ Debugging tools {{{1

: a. ( a -- )
  dup hex. ." (#" 0 .r ." )" ;
  \ Display a target address. Used in debugging messages.

: .m ( a n -- ) swap memory + swap dump ;
  \ Dump _n_ bytes from target memory address _a_.

: [.o] ( -- ) cr .order ; immediate
  \ Display the current search order.

: [.s] ( -- ) cr .s ; immediate
  \ Display the host data stack.

: compiler-words ( -- ) postpone compiler{ words previous ;
  \ Display the words defined in the compiler word list.

: target-words ( -- ) postpone target{ words previous ;
  \ Display the words defined in the target word list.

\ ==============================================================
\ Compiler {{{1

: t-cells ( n1 -- n2 )
  2 * ;
  \ Convert _n1_ cells to the equivalent _n2_ address units in the
  \ target system.

: t-here ( -- a )
  memory> @ ;
  \ Return the target data-space pointer address _a_ ($0000..$FFFF).

: h-here ( -- a )
  t-here memory + ;
  \ Return the host address _a_ that is the current equivalent
  \ address of the target data-space pointer in the host `memory`
  \ buffer.

include sin_forth/src/assembler.fs

variable latest-call
  \ Target address where the latest Z80 `call` to a target word
  \ definition was compiled. This is used by `;` in order to optimize
  \ the last call compiled in the current word.

: dea-constant ( ca len a -- )
  >r s" _dea" s+ nextname r> constant ;
  \ Create a constant with the target entry name _ca len_ and the
  \ "_dea" suffix, with value _a_ which is its DEA (definition entry
  \ address), i.e. the target memory address where the entry is
  \ defined. For example, the DEA of the target word `=` will be
  \ returned by the compiler constant `=_dea`. These constants make it
  \ possible to manipulate the compiled code by the compiled program,
  \ without using the compiler `'` during the compilation.

: creator ( "name" -- a )
  parse-name 2dup memory> @ dea-constant
                  nextname create memory> @
\  cr ." Compiling at " memory> @ a. \ XXX INFORMER
\     ."  the word `" latest .name ." `" \ XXX INFORMER
  z80-symbols @ if memory> @ latest z80-symbol then ;
  \ Create a host header for word _name_ and return the current target
  \ address _a_ associated to it.

: do-call ( dfa -- )
  @  memory> @ latest-call !
\  cr ." Compiling at " memory> @ a. \ XXX INFORMER
\     ."  a call to " dup a. \ XXX INFORMER
  assembler{ call, } ;

: : ( "name" -- )
  creator dup latest-colon ! ,
  does> ( dfa ) do-call ;

  \ doc{
  \
  \ : ( "name" -- ) "colon"
  \
  \ Parse _name_. Create a host definition for _name_, called a "colon
  \ definition". When _name_ is later found, a Z80 `call,` is executed
  \ to compile a call to the target address where ``:`` was found.
  \
  \ Usage example:

  \ ----
  \ : inc ( n1 -- n2 )
  \   pop-hl
  \   h incp,
  \   push-hl ;
  \
  \ : .pair ( n -- )
  \   dup . inc . ;
  \ ----

  \ NOTE: Sin Forth's ``:`` has nothing to do with standard Forth's
  \ ``:``. In Sin Forth, ``:`` is similar to an assembler label: It
  \ marks an arbitrary entry point. In fact several ``:`` can be used
  \ in one single definition, as the following example shows:

  \ ----
  \ : inc ( n1 -- n2 )
  \   pop-hl
  \ : inc-hl ( -- n2 )
  \   h incp,
  \   push-hl ;
  \ ----

  \ NOTE: ``:`` is part of the compiler, it's not defined in the
  \ target.
  \
  \ See also: `;`.
  \
  \ }doc

: tail-call? ( -- f )
  latest-call @ memory> @ 3 - = ;
  \ Was the latest Z80 call compiled 3 bytes before the current target
  \ memory pointer?

: optimize-ret ( -- )
  $C3 latest-call @ t-c! ;
  \ Replace the latest Z80 call with a jump (opcode $C3).

: ; ( -- )
\  cr ." Compiling at " memory> @ a. ."  a `;`" \ XXX INFORMER
  tail-call? if optimize-ret else ret, then ;

  \ XXX TODO Improve the documentation. Add an example where several
  \ `;` are used in a definition.

  \ doc{
  \
  \ ; ( -- ) "semicolon"
  \
  \ Mark the end of a definition, executing an assembler `ret,` in
  \ order to compile a return from the current definition.
  \
  \ ``;`` does tail optimization: If the latest compiled instruction
  \ was a Z80 call, it is replaced with a jump instead of executing
  \ `ret,`.
  \
  \ NOTE: Sin Forth's ``;`` has nothing to do with standard Forth's
  \ ``;``. In Sin Forth, ``;`` just compiles the return from a Z80
  \ subrutine. In fact several ``;`` can be used in one single
  \ definition.
  \
  \ NOTE: ``;`` is part of the compiler, it's not defined in the
  \ target.
  \
  \ See also: `:`.
  \
  \ }doc

\ ==============================================================
\ Data stack {{{1

64 constant /default-data-stack

  \ doc{
  \
  \ /default-data-stack ( -- len )
  \
  \ Return the size _len_, in target cells, of the default data
  \ stack created by `end-program` when `data-stack` has not been
  \ included in the target program.
  \
  \ }doc

-1 constant fake-data-stack-bottom
fake-data-stack-bottom value data-stack-bottom
  \ Set `data-stack-bottom` with a fake default value, in
  \ order to detect whether it has been set or not.

: data-stack? ( -- f )
  data-stack-bottom fake-data-stack-bottom <> ;
  \ Has been a data stack defined?

: data-stack ( len -- )
  data-stack? abort" second `data-stack`"
  t-cells z80dasm-blocks @ if memory> @ over z80dasm-stack-block then
  memory> +!  memory> @ to data-stack-bottom ;

  \ doc{
  \
  \ data-stack ( len -- )
  \
  \ Create the data stack, with _len_ target cells, at the current
  \ target memory pointer. The data stack grows towards 
  \ low memory. If ``data-stack`` is not executed during the
  \ compilation of the target program, it will be executed by
  \ `end-program` with the default size returned by
  \ `/default-data-stack`.
  \
  \ }doc

\ ==============================================================
\ Output files {{{1

: new-file ( ca len -- fid )
  w/o create-file throw ;
  \ Create a new file _ca len_ returning its file identifier _fid_.

variable target-name ( -- a )
  \ Address of a dynamic string containing the basename of the source
  \ file, without extension, reused for target files.

variable target-path ( -- a )
  \ Address of a dynamic string containing by default the path of the
  \ source file, reused for target files. This can be configured with
  \ a command-line option.

target-path $init
  \ Init `target-path` with an empty string. This will be checked when
  \ parsing the command line arguments, in order to use the source
  \ path instead or not.

\ ----------------------------------------------
\ Sinclair BASIC loader file {{{2

false value build-loader?
  \ Flag, configurable with a command-line option.

: .loader ( -- )
  .\" 1 CLEAR VAL\"" origin 1 - 0 .r
  .\" \":LOAD \"\" CODE VAL\"" origin 0 .r
  .\" \":RANDOMIZE USR VAL\"" boot-address @ 0 .r '"' emit ;
  \ Display a one-line Sinclair BASIC program (in text format) which
  \ loads the next binary file on the tape into memory address
  \ `origin`, and execute it at address `boot-address`.

: build-loader ( ca len -- )
  s" .bas" s+ new-file dup >r
  ['] .loader swap outfile-execute
  r> close-file throw ;
  \ Create a Sinclair BASIC loader (in text format), with base
  \ filename _ca len_ (with path but without extension) and the ".bas"
  \ extension, which loads the next binary file on the tape into
  \ memory address `origin`, and execute it at address `boot-address`.

\ ----------------------------------------------
\ Code file addresses {{{2

false value build-addresses?
  \ Flag, configurable with a command-line option.

: build-boot-address ( ca len -- )
  s" .boot.txt" s+ new-file dup >r
  [: boot-address @ 0 .r ;] swap outfile-execute
  r> close-file throw ;
  \ Create a text file containing the boot code address, with
  \ base filename _ca len_ (with path but without extension). The
  \ content of this file can be used by the building tool as a
  \ parameter of bin2tap.

: build-origin-address ( ca len -- )
  s" .origin.txt" s+ new-file dup >r
  [: origin 0 .r ;] swap outfile-execute
  r> close-file throw ;
  \ Create a text file containing the origin code address, with
  \ base filename _ca len_. The content of this file can be used by
  \ the building tool as a parameter of bin2tap.

\ ----------------------------------------------
\ ZX Spectrum code file {{{2

false value build-code?
  \ Flag, configurable with a command-line option.

: /code ( -- len )
  memory> @ origin - ;
  \ Return the size _len_ of the target code.

: build-code ( ca len -- )
  s" .bin" s+ new-file >r
  memory origin + /code r@ write-file throw
  r> close-file throw ;
  \ Create a Z80 code file with filename _ca len_ and the ".bin"
  \ extension.

\ ----------------------------------------------
\ ZX Spectrum .tap file {{{2

false value build-tap?
  \ Flag, configurable with a command-line option.

: bin2tap {: D: name -- ca len :}
  "bin2tap " name s+ ".bin " s+
             name s+ ".tap " s+
             origin n>str s+ " " s+
             boot-address @ n>str s+ ;
  \ Convert the given _name_ (a path with a filename without
  \ extension) into a `bin2tap` command to convert a .bin file into a
  \ .tap file.

: (build-tap) {: D: name -- :}
  name bin2tap
  system $? abort" external program bin2tap failed" ;
  \ Create a .tap file using the external tool `bin2tap`. Note: _name_
  \ is a string containing the path and filename without extension.

: build-tap {: D: name -- :}
  build-code? 0= if name build-code then
  name (build-tap)
  build-code? 0= if name ".bin" s+ delete-file throw then ;
  \ Create a .tap file using the external tool `bin2tap`. If the
  \ required code file has not been created, create it first and
  \ delete it at the end. Note: _name_ is a string containing the path
  \ and filename without extension.

\ ----------------------------------------------
\ Z80 assembly symbols file {{{2

false value build-z80-symbols?
  \ Flag, configurable with a command-line option.

: (build-z80-symbols) ( ca len -- )
  s" .symbols.asm" s+ z80-symbols$ $@ 2swap unslurp-file ;
  \ Create a Z80 symbols file with base filename _ca len_.

: build-z80-symbols ( ca len -- )
  z80-symbols$ $@len if (build-z80-symbols) else 2drop then ;
  \ If there are symbols listed during the compilation, create a Z80
  \ symbols file with base filename _ca len_. Otherwise do nothing.

\ ----------------------------------------------
\ z80dasm disassembler blocks file {{{2

false value build-z80dasm-blocks?
  \ Flag, configurable with a command-line option.

: (build-z80dasm-blocks) ( ca len -- )
  s" .z80dasm_blocks.txt" s+ z80dasm-blocks$ $@ 2swap unslurp-file ;
  \ Create a z80dasm blocks file with base filename _ca len_.

: build-z80dasm-blocks ( ca len -- )
  z80dasm-blocks$ $@len if (build-z80dasm-blocks) else 2drop then ;
  \ If there are z80dasm-blocks collected during the compilation,
  \ create a z80dasm blocks file using base filepath without extension
  \ _ca len_. Otherwise do nothing.

\ ----------------------------------------------
\ Build files {{{2

: ?build-file ( ca len xt flag -- )
  if execute else drop 2drop then ;
  \ If _flag_ is not false, execute _xt_ with the given filename _ca
  \ len_ (with path and without extension); otherwise just discard the
  \ arguments.

: build-files ( -- )
  target-path $@ target-name $@ s+
  2dup ['] build-loader         build-loader?         ?build-file
  2dup ['] build-boot-address   build-addresses?      ?build-file
  2dup ['] build-origin-address build-addresses?      ?build-file
  2dup ['] build-code           build-code?           ?build-file
  2dup ['] build-tap            build-tap?            ?build-file
  2dup ['] build-z80-symbols    build-z80-symbols?    ?build-file
       ['] build-z80dasm-blocks build-z80dasm-blocks? ?build-file ;
  \ Build all of the target files whose building flags (set by their
  \ corresponding command-line options) are not false.

\ ==============================================================
\ Target memory additional tools {{{1

: t-allot \ Compilation: ( +n -- )
  dup 0< abort" Negative number not allowed by `t-allot`"
  z80dasm-blocks @ if dup z80dasm-allot-block then
  memory> +! ;
  \ A compiler version of `allot` that handles the data-space
  \ pointer of the target.

: t-char+ ( n1 -- n2 )
  1+ ;
  \ Add the size in bytes of a target character to _n1_, giving
  \ _n2_.

: t-s, ( ca len -- )
  \ XXX TODO
  tuck h-here place t-char+ t-allot ;

  \ doc{
  \
  \ t-s, ( ca len -- ) "s-comma"
  \
  \ Compile the string _ca len_ in target data space.
  \
  \ ``t-s,`` is a compiler version of `s,` which works in target data
  \ space.
  \
  \ See also: `t-allot`.
  \
  \ }doc

\ ==============================================================
\ Compiler directives {{{1

: begin-program ( -- )
  target-definitions ;
  \ Mark the start of the target program.

: end-program ( -- )
  data-stack? 0= if /default-data-stack data-stack then
  no-boot?       if set-default-boot               then
  boot-address @ s" __BOOT_HERE" (z80-symbol)
  build-files
  bye ;
  \ Mark the end of the target program.

\ ==============================================================
\ Command-line arguments {{{1

: next-arg? ( -- ca len f )
  next-arg 2dup 0 0 d<> ;

\ ----------------------------------------------
\ Options {{{2

: addr-option    ( -- ) true to build-addresses? ;
: bas-option     ( -- ) true to build-loader? ;
: code-option    ( -- ) true to build-code? ;
: sym-option     ( -- ) true to build-z80-symbols? ;
: tap-option     ( -- ) true to build-tap? ;
: z80dasm-option ( -- ) true to build-z80dasm-blocks? ;

: out-option ( -- )
  next-arg? if   "/" s+ target-path $!
            else ." Error: the out directory is missing." abort then ;
  \ Get the value of the `--out` option.

\ ----------------------------------------------
\ Commands {{{2

: (build-command) {: D: source-file -- :}
  source-file file-exists?
  if   source-file basename -extension target-name $!
       target-path $@len 0= if source-file dirname target-path $! then
       source-file included
  else ." Error: the source file does not exist:" cr
       source-file type
       abort
  then ;
  \ If the given source file exists, compile it; otherwise display an
  \ error and abort.

: build-command ( -- )
  next-arg? if   (build-command)
            else ." Error: the source file is missing." abort then ;
  \ If there's a next argument, use it as source file; otherwise
  \ display an error and abort.

: version-command ( -- )
  ." Sin Forth " "VERSION.txt" slurp-file type ;
  \ Display the version number.

: help-command ( -- )
  version-command
  ." By Marcos Cruz (programandala.net), 2010/2023." cr cr
  ." Usage:" cr
  ."     " sourcefilename basename type ."  [OPTION...] COMMAND" cr
  ." Commands:" cr
  ."     build <filepath>" cr
  ."         Compile the given source file (with its absolute path)." cr
  ."         Note: no file will be built by default. See the build" cr
  ."         options below." cr
  ."     help" cr
  ."         Display this help message." cr
  ."     version" cr
  ."         Display the version number." cr
  ." Build command options:" cr
  ."     --addr|-addr|-a" cr
  ."         Build the text files containing the origin and boot addresses" cr
  ."         of the compiled code. These may be used by external tools in" cr
  ."         order to make a custom loader for the target machine." cr
  ."     --bas|-bas|-b" cr
  ."         Build a text-format Sinclair BASIC loader for the compiled code." cr
  ."     --code|-code|-c" cr
  ."         Build a headerless ZX Spectrum code file." cr
  ."     --out|-out|-o <path>" cr
  ."         Set the absolute path of the output files. If this option" cr
  ."         is not used, the path of the source file is used." cr
  ."     --sym|-sym|-s" cr
  ."         Build a Z80 symbols file. This is useful to disassemble" cr
  ."         the compiled code with a disassembler, for example z80dasm." cr
  ."     --tap|-tap|-t" cr
  ."         Build a .tap file ready to be loaded into a ZX Spectrum" cr
  ."         emulator. Note: bin2tap (https://metalbrain.speccy.org/link-eng.htm)" cr
  ."         must be installed in the system." cr
  ."     --z80dasm|-z80dasm|-z" cr
  ."         Build a z80dasm blocks file. This is useful to disassemble" cr
  ."         the compiled code with the z80dasm disassembler.' cr
  cr
  ." NOTE: The paths must be absolute. This requirement may be removed" cr
  ." in a future version of the compiler." cr ;

\ ----------------------------------------------
\ Parser {{{2

: parse-argument {: D: argument -- :}
  argument "build"     str= if build-command   exit then
  argument "help"      str= if help-command    exit then
  argument "version"   str= if version-command exit then
  argument "--addr"    str= if addr-option     exit then
  argument "-addr"     str= if addr-option     exit then
  argument "-a"        str= if addr-option     exit then
  argument "--bas"     str= if bas-option      exit then
  argument "-bas"      str= if bas-option      exit then
  argument "-b"        str= if bas-option      exit then
  argument "--code"    str= if code-option     exit then
  argument "-code"     str= if code-option     exit then
  argument "-c"        str= if code-option     exit then
  argument "--out"     str= if out-option      exit then
  argument "-out"      str= if out-option      exit then
  argument "-o"        str= if out-option      exit then
  argument "--sym"     str= if sym-option      exit then
  argument "-sym"      str= if sym-option      exit then
  argument "-s"        str= if sym-option      exit then
  argument "--tap"     str= if tap-option      exit then
  argument "-tap"      str= if tap-option      exit then
  argument "-t"        str= if tap-option      exit then
  argument "--z80dasm" str= if z80dasm-option  exit then
  argument "-z80dasm"  str= if z80dasm-option  exit then
  argument "-z"        str= if z80dasm-option  exit then ;

: parse-arguments ( -- )
  argc @ 1 = if help-command exit then
  begin next-arg? while parse-argument repeat 2drop ;

parse-arguments bye

\ vim: filetype=gforth
