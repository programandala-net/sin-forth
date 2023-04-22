\ lib/then.fs

\ This file is part of Sin Forth.

\ This file adds `then` to the compiler.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require forward-resolve.fs \ `>resolve`

get-order get-current

compiler-definitions

compiler{

synonym then >resolve

}

  \ doc{
  \
  \ then
  \   Compilation: ( orig -- )
  \   Run-time:    ( -- )

  \
  \ Resolve the forward reference _orig_, usually left by `if`,
  \ `while` or `after`.
  \
  \ ``then`` is a synonym of `>resolve`.
  \
  \ // XXX TODO See also: `else`, `ahead`.
  \
  \ }doc

set-current set-order
