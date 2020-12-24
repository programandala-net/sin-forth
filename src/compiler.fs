#! /usr/bin/env gforth

\ compiler.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2010, 2015, 2020.

\ Last modified: 202012130025.
\ See change log at the end of the file.

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

require galope/minus-suffix.fs \ `-suffix`
require galope/n-to-str.fs     \ `n>str`
require galope/replaced.fs     \ `replaced`
require galope/unslurp-file.fs \ `unslurp-file`

warnings on

\ ==============================================================
\ Word lists {{{1

only forth definitions  decimal

wordlist constant compiler-wordlist
  \ The compiler word list.

wordlist constant target-wordlist
  \ The target system word list.

: compiler-order ( -- )
  only
  target-wordlist >order
  compiler-wordlist >order
  forth-wordlist >order ;

: compiler-definitions ( -- )
  compiler-order
  compiler-wordlist set-current ;

: target-order ( -- )
  only
  compiler-wordlist >order
  target-wordlist >order ;

: target-definitions ( -- )
  target-order  
  target-wordlist set-current ;

: host{ ( -- )
  forth-wordlist >order ; immediate

: compiler{ ( -- )
  compiler-wordlist >order ; immediate

: target{ ( -- )
  target-wordlist >order ; immediate

: } ( -- )
  previous ; immediate

compiler-wordlist set-current

synonym compiler-definitions compiler-definitions
synonym compiler-order compiler-order
synonym target-definitions target-definitions
synonym target-order target-order

synonym } }
synonym compiler{ compiler{
synonym host{ host{
synonym target{ target{ 

target-wordlist set-current

synonym compiler-definitions compiler-definitions
synonym compiler-order compiler-order
synonym target-definitions target-definitions
synonym target-order target-order

synonym } }
synonym compiler{ compiler{
synonym host{ host{
synonym target{ target{ 

\ ==============================================================
\ Standard words needed during the compilation {{{1

compiler-definitions

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

\ ==============================================================
\ Target memory {{{1

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
  \ Set the initial target memory address _a_ from wich the code will
  \ be compiled. Its default value is $5E00 (24064).
  \
  \ ``set-origin`` should be used before any target code is compiled,
  \ including library modules.
  \
  \ }doc

\ ----------------------------------------------
\ set-filename {{{2

variable filename> ( -- a )
  \ Address of the string stored by `set-filename` as a counted
  \ string.

: filename ( -- ca len )
  filename> @ count ;
  \ Return the string set by `set-filename`.

: set-filename ( ca len -- )
  here >r s, r> filename> ! ;

s" out" set-filename \ default value

  \ doc{
  \
  \ set-filename ( ca len -- )
  \
  \ Set the filename of the output files to string _ca len_, not
  \ including the extension, which will be added automatically.
  \
  \ Its default value is "out". Therefore the default names of the
  \ output files are "out.bas" (the target BASIC loader) and "out.bin"
  \ (the target executable).
  \
  \ WARNING: Since a 4-character filename extension is added to the
  \ filename, _len_ should be at least 4 characters less than the
  \ maximun filename length allowed by the target media or DOS.
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
  \ BASIC loader. ``boot-here`` should be used right after a `:`
  \ definition.
  \
  \ When ``boot-here`` is not used, the boot address will be that of
  \ the latest `:` definition.
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

: z80dasm-stack-block ( a len -- )
  over + s" worddata" s" data_stack" false false z80dasm-block ;
  \ Create a z80dasm block definition for the data stack, whose top
  \ (low address) is at target memory address
  \ _a_ and its length is _len_ bytes.

\ ==============================================================
\ Debugging tools {{{1

: a. ( a -- )
  dup hex. ." (#" 0 .r ." )" ;
  \ Display a target address. Used in debugging messages.

: .m ( a n -- ) swap memory + swap dump ;
  \ Dump _n_ bytes from target memory address _a_.

: compiler-words ( -- ) compiler-wordlist >order words previous ;
  \ Display the words defined in the compiler word list.

: target-words ( -- ) target-wordlist >order words previous ;
  \ Display the words defined in the target word list.

\ ==============================================================
\ Compiler {{{1

include assembler.fs

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
  call, ;

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
  \ ``:``. In Sin Forth, ``:`` is similar to a assembler label: It
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

  \ NOTE: Sin Forth's ``;`` has nothing to do with standard Forth's
  \ ``;``. In Sin Forth, ``;`` just compiles the return from a Z80
  \ subrutine. In fact several ``;`` can be used in one single
  \ definition.

  \ NOTE: ``;`` is part of the compiler, it's not defined in the
  \ target.

  \ See also: `:`.
  \
  \ }doc

\ ==============================================================
\ Data stack {{{1

64 constant /stack

  \ doc{
  \
  \ /stack ( -- len )
  \
  \ Return the size _len_, in in target cells, of the default data
  \ stack created by `end-program` when `data-stack-here` has not been
  \ included in the target program.
  \
  \ }doc

-1 constant no-data-stack
no-data-stack value data-stack-bottom
  \ Store an impossible default value into `data-stack-bottom`, in
  \ order to detect whether it has been set or not.

: no-data-stack? ( -- f )
  data-stack-bottom no-data-stack = ;
  \ Has `data-stack-bottom` not been set?
  \ I.e., has `data-stack-here` not been executed before?

: data-stack-here ( len -- )
  no-data-stack? 0= abort" second `data-stack-here` not allowed"
  2 * z80dasm-blocks @ if memory> @ over z80dasm-stack-block then
  memory> +!  memory> @ to data-stack-bottom ;

  \ doc{
  \
  \ data-stack-here ( len -- )
  \
  \ Create the data stack, _len_ target cells big, at the current
  \ target memory pointer. The data stack grows from bottom (high
  \ memory) to top (low memory). If ``data-stack-here`` is not
  \ executed during the compilation of the target program, it will be
  \ executed by `end-program` with the default size returned by
  \ `/stack`.
  \
  \ }doc

\ ==============================================================
\ Output files {{{1

: new-file ( ca len -- fid )
  w/o create-file throw ;
  \ Create a new file _ca len_ returning its file identifier _fid_.

\ ----------------------------------------------
\ Sinclair BASIC loader file {{{2

: .loader ( -- )
  .\" 1 CLEAR VAL\"" origin 1 - 0 .r
  .\" \":LOAD \"\" CODE VAL\"" origin 0 .r
  .\" \":RANDOMIZE USR VAL\"" boot-address @ 0 .r '"' emit ;
  \ Display a one-line Sinclair BASIC program to load a binary file
  \ whose basename is _ca len_, with an added ".bin" extension",
  \ into memory address `origin`, and execute it at that address. The
  \ execution token of ``.loader`` is used by `loader` in order to
  \ redirect the standard output produced by ``.loader`` to a file.

: create-loader ( ca len -- )
  s" .bas" s+ new-file dup >r
  ['] .loader swap outfile-execute
  r> close-file throw ;
  \ Create a Sinclar BASIC loader (in text format) with
  \ filename _ca len_ and the ".bas" extension, to load its
  \ corresponding code file with the ".bin" extension.

\ ----------------------------------------------
\ ZX Spectrum executable file {{{2

: /executable ( -- len )
  memory> @ origin - ;
  \ Return the size _len_ of the target executable.

: create-executable ( ca len -- )
  s" .bin" s+ new-file >r
  memory origin + /executable r@ write-file throw
  r> close-file throw ;
  \ Create a Z80 code file with filename _ca len_ and the ".bin"
  \ extension.

\ ----------------------------------------------
\ Z80 assembly symbols file {{{2

: (create-z80-symbols) ( ca len -- )
  s" .symbols.asm" s+ z80-symbols$ $@ 2swap unslurp-file ;
  \ Create a Z80 symbols file with base filename _ca len_.

: create-z80-symbols ( ca len -- )
  z80-symbols$ $@len if (create-z80-symbols) else 2drop then ;
  \ If there are symbols listed during the compilation, create a Z80
  \ symbols file with base filename _ca len_. Else do nothing.

\ ----------------------------------------------
\ z80dasm disassembler blocks file {{{2

: (create-z80dasm-blocks) ( ca len -- )
  s" .z80dasm_blocks.txt" s+ z80dasm-blocks$ $@ 2swap unslurp-file ;
  \ Create a z80dasm blocks file with base filename _ca len_.

: create-z80dasm-blocks ( ca len -- )
  z80dasm-blocks$ $@len if (create-z80dasm-blocks) else 2drop then ;
  \ If there are z80dasm-blocks collected during the compilation,
  \ create a z80dasm blocks file with base filename _ca len_. Else do
  \ nothing.

\ ==============================================================
\ Compiler directives {{{1

: begin-program ( -- )
  target-definitions ;
  \ Mark the start of the target program.

: end-program ( -- )
  no-data-stack? if /stack data-stack-here  then
  no-boot?       if set-default-boot        then
  boot-address @ s" __BOOT_HERE" (z80-symbol)
  filename 2dup create-loader
           2dup create-executable
           2dup create-z80-symbols
                create-z80dasm-blocks
  only forth definitions bye ;
  \ Mark the end of the target program.

\ ==============================================================
\ Change log {{{1

\ 2010-04-21: First draft ideas.
\
\ 2015-01-06: More drafts.
\
\ 2020-12-06: Resume the development. New draft. Adapt and integrate
\ the assembler from Solo Forth 0.14.0-rc.124+20201123. Adapt and
\ integrate the data stack code from Couplement Forth
\ v0.2.0-dev.30.0+202012062153.
\
\ 2020-12-07: Start the target kernel words. Move the sample
\ compilable test code to its own file. Move the target definitions to
\ a library, and also the compiler definitions `variable` and
\ `constant`. Factor `header` from `:`.
\
\ 2020-12-08: Add code to create the targets files. Document `:` and
\ `;`. Add `begin-program`, `end-program`, `set-origin`,
\ `set-filename`, `boot-here`. Create a Z80 assembly symbols file.
\ Create a z80dasm disassembler blocks definitions file.
\
\ 2020-12-09: Make the address and size of the data stack
\ configurable. Rename this file from <sin_forth.fs> to <compiler.fs>.
\
\ 2020-12-10: Deactivate debugging messages. Deactivate `warnings`
\ while loading the requirements. Add `bye` to `end-program`. Rename
\ `header` to `creator`. Remove the executable name from the BASIC
\ loader. Simplify `new-file`.
\
\ 2020-12-11: Improve the word lists. Select the host Forth words that
\ are recognized during the compilation. Add immediate words to modify
\ the search order during compilation. Improve `>z80-label`. Factor
\ `do-call` from `:`, to reuse it in `defer`.
\
\ 2020-12-12: Improve `>z80-label`. Add `dea-constant` to make
\ `creator` create a DEA compiler constant for every definition.
\
\ 2020-12-13: Add `target-wordlist` at the bottom of the search order
\ set by `compiler-order`.
