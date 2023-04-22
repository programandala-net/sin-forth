\ test_move.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1745+0200.

\ ==============================================================

40000 set-origin
s" test_move" set-filename

begin-program

require sin_forth/lib/allot.fs
require sin_forth/lib/constant.fs
require sin_forth/lib/create.fs
require sin_forth/lib/for.fs
require sin_forth/lib/literal.fs
require sin_forth/lib/move-hl-de-bc.fs
require sin_forth/lib/pop-de.fs
require sin_forth/lib/pop-hl.fs
require sin_forth/lib/r-fetch.fs
require sin_forth/lib/step.fs

22528 h-constant attr
768 h-constant /attr

compiler{ memory> } h-@ h-constant attr-copy
/attr t-allot

: save-attr ( -- )
  attr h ldp#,
  attr-copy d ldp#,
  /attr b ldp#,
  move-hl-de-bc ;

: restore-attr ( -- )
  attr-copy h ldp,
: hl-to-attr ( -- )
  attr d ldp#,
  /attr b ldp#,
  move-hl-de-bc ;

: wait ( -- )
  65535 literal for [.s] step ;

: rubbish ( u -- )
  for r@ pop-hl hl-to-attr step ;

: run ( -- )

boot-here
exx, h push,

\ 0 h ldp#,
\ attr d ldp#,
\ /attr b ldp#,
\ move-hl-de-bc

save-attr
1024 literal rubbish
restore-attr

h pop, exx,
ret,

4 data-stack

end-program
