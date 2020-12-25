\ lib/then.fs

\ This file is part of Sin Forth.

\ This file adds `then` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012251742.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-12: Document.
\
\ 2020-12-25: Update documentation with `after`.
